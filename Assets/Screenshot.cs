using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Screenshot : MonoBehaviour
{
    public Camera ARCamera;

    public void CaptchaScreen()
    {
        Texture2D screenshot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        RenderTexture rt = new RenderTexture(screenshot.width, screenshot.height, 24);
        RenderTexture prev = ARCamera.targetTexture;
        ARCamera.targetTexture = rt;
        ARCamera.Render();
        ARCamera.targetTexture = prev;
        RenderTexture.active = rt;
        screenshot.ReadPixels(new Rect(0, 0, screenshot.width, screenshot.height), 0, 0);
        screenshot.Apply();

        byte[] bytes = screenshot.EncodeToPNG();
        UnityEngine.Object.Destroy(screenshot);
        string fileName = "mayu_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".png";
        string path;
        using (AndroidJavaClass jcEnvironment = new AndroidJavaClass("android.os.Environment"))
        using (AndroidJavaObject joExDir = jcEnvironment.CallStatic<AndroidJavaObject>("getExternalStorageDirectory"))
        {
            path = joExDir.Call<string>("toString") + "/MayuSuki";
        }
        //フォルダがなければ作成
        if (!Directory.Exists(path)) Directory.CreateDirectory(path);
        var screenshotPath = path + "/" + fileName;
        File.WriteAllBytes(screenshotPath, bytes);
        ScanMedia(screenshotPath);
    }


    void ScanMedia(string filePath)
    {
        if (Application.platform != RuntimePlatform.Android) return;
#if UNITY_ANDROID
        using (AndroidJavaClass jcUnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        using (AndroidJavaObject joActivity = jcUnityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
        using (AndroidJavaObject joContext = joActivity.Call<AndroidJavaObject>("getApplicationContext"))
        using (AndroidJavaClass jcMediaScannerConnection = new AndroidJavaClass("android.media.MediaScannerConnection"))
            jcMediaScannerConnection.CallStatic("scanFile", joContext, new string[] {filePath},
                new string[] {"image/png"}, null);

        Handheld.StopActivityIndicator();
#endif
    }
}