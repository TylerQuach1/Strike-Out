using UnityEngine;

public class Contact : MonoBehaviour //Script for passing rigidbody velocity to ball as external physics
{
    AudioSource sound;
    void Awake() //get audio source on spawn
    {
        sound = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ball") //if ball collides with batfollower then collision occurs
        { 
            sound.Play();
            collision.gameObject.GetComponent<Rigidbody>().AddForce(GetComponent<BatCapsuleFollower>().GetVelocity()*(2f), ForceMode.Impulse); //grabs bat velocity and passes it as impulse force on the ball
            collision.gameObject.GetComponent<Rigidbody>().drag = 0.3f; //adjust drag for ball friction
            collision.gameObject.GetComponent<Ball>().ballHit = true; 
        }
    }

}
