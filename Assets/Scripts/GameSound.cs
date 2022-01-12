using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSound : MonoBehaviour
{
    public Slider slider;

    public void Louder()
    {
        if (slider.value < 100)
        {
            slider.value += 16.7f;
            CL.Volume += 0.167f;
        }
    }
    
    public void Quiet()
    {
        if (slider.value > 0)
        {
            slider.value -= 16.7f;
            CL.Volume -= 0.167f;
        }
    }
}
