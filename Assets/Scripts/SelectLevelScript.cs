using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLevelScript : MonoBehaviour
{
    public GameObject Buttons;
    public Sprite unActBut;
    public Sprite ActBut;

    private void Start()
    {
        var len = Buttons.GetComponentsInChildren<Button>().Length;
        for (int i = 0; i < len; i++)
        {
            var curButton = Buttons.GetComponentsInChildren<Button>()[i];
            curButton.enabled = false;
            curButton.GetComponent<Image>().sprite = unActBut;
        }

        for (int i = 0; i <= CL.CurrentLevel - 1; i++)
        {
            var curButton = Buttons.GetComponentsInChildren<Button>()[i];
            curButton.enabled = true;
            curButton.GetComponent<Image>().sprite = ActBut;
        }
    }
}
