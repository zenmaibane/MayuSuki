using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeAnim : MonoBehaviour
{
    public Dropdown Menu;
    public Animator Animator;

    public void ChangeMotion()
    {
        var selectedNum = Menu.value;
        switch (selectedNum)
        {
            case 0:
                Animator.Play("Wait01");
                break;
            case 1:
                Animator.Play("WAIT02");
                break;
            case 2:
                Animator.Play("POSE31");
                break;
            case 3:
                Animator.Play("POSE01");
                break;
            case 4:
                Animator.Play("Sitting01");
                break;
            case 5:
                Animator.Play("POSE19");
                break;
            case 6:
                Animator.Play("POSE07");
                break;
            case 7:
                Animator.Play("POSE16");
                break;
        }
    }
}
