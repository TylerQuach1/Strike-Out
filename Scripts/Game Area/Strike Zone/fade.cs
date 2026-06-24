using System.Collections;
using UnityEngine;

public class fade : MonoBehaviour //strikeZone indicator fade away script
{
    void Start()
    {
        StartCoroutine(fadeAway());
    }

    private IEnumerator fadeAway() //fade away after 2 seconds
    {
       
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }

}
