using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderEvent : MonoBehaviour
{
    public GameObject Model;
    public Slider Slider;

    public void ChangeModelScale()
    {
        Model.transform.localScale = new Vector3(Slider.value, Slider.value, Slider.value);
    }
}
