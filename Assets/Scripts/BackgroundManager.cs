using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour
{
    public Sprite Forest;
    public Sprite Road;
    public Sprite GrafHouse;

    public Image CurrentBackground;

    public void ChangeBackground(string name)
    {
        switch (name)
        {
            case "forest":
                CurrentBackground.GetComponent<Image>().sprite = Forest;
                break;
            case "road":
                CurrentBackground.GetComponent<Image>().sprite = Road;
                break;
            case "grafHouse":
                CurrentBackground.GetComponent<Image>().sprite = GrafHouse;
                break;
        }
    }
}
