using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Required when Using UI elements.

public class Example : MonoBehaviour
{
    public Slider mainSlider;

    public void SubmitSliderSetting()
    {
        Debug.Log(mainSlider.value);
    }
}