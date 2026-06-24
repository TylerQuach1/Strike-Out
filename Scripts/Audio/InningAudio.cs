using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InningAudio : MonoBehaviour
{
    public List<AudioClip> inningList;
    public void playRandominning()
    {
        AudioClip randomClip = inningList[Random.Range(0, inningList.Count)];
        GetComponent<AudioSource>().PlayOneShot(randomClip);
    }

}
