using UnityEngine;

public class MMSound : MonoBehaviour
{
    public AudioSource mainMenuSound;

    void Update()
    {
        mainMenuSound.volume = CL.Volume;
    }
}
