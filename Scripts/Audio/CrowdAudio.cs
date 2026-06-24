using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CrowdAudio : MonoBehaviour
{
    public List<AudioClip> crowd;

    public void muteAudio()
    {
        GetComponent<AudioSource>().mute = true;
    }

    public void playAudio()
    {
        GetComponent<AudioSource>().mute = false;
    }

    public void playSad()
    {
        GetComponent<AudioSource>().PlayOneShot(crowd[1]);
    }

    public void playHappy()
    {
        GetComponent<AudioSource>().PlayOneShot(crowd[2]);
    }
}
