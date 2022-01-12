using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource Paper;
    public AudioSource Telephone;
    public AudioSource Horror;
    public AudioSource House;

    public void PlaySound(string NameSound)
    {
        switch (NameSound)
        {
            case "paper":
                Paper.volume = CL.Volume;
                Paper.Play();
                break;
            case "telephone":
                Telephone.volume = CL.Volume;
                Telephone.Play();
                break;
            case "horror":
                Horror.volume = CL.Volume;
                House.Stop();
                Horror.Play();
                break;
            case "house":
                House.volume = CL.Volume / 5;
                Horror.Stop();
                House.Play();
                break;
        }
    }
}
