using UnityEngine;

public class foulZone : MonoBehaviour //Script for detecting if balls are foul balls
{
    public GameObject pitchingCannon;

    private void OnTriggerEnter(Collider other) //if ball collides with foul zone trigger zone
    {
        if (other.gameObject.tag == "ball" && other.gameObject != null)//if ball and still exist
        {
            pitchingCannon.GetComponent<PitchingCannon>().valid = false; //set ball as invalid
            if (!other.gameObject.GetComponent<Ball>().ballDestroy)//if ball is not currently being destroyed call destroyBall function
            {
                StartCoroutine(other.gameObject.GetComponent<Ball>().DestroyBall());
            }
        }
    }
}
