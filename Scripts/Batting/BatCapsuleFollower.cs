using UnityEngine;

public class BatCapsuleFollower : MonoBehaviour //Script which ties followerCapsule rigidbodies to batCapsules which act as hitboxes and transfer velocity to ball
{
    private BatCapsule batFollower; //capsule tied to bat
    private Rigidbody rb; //follower capsule rigid body
    private Vector3 velocity; //follower capsule velocity

    private void Awake() //when capsule instanciated get the rigid body
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() //calculate the difference between the batCapsule and CapsuleFollower(rigidbody), change in position is the velocity of the bat
    {
        velocity = (batFollower.transform.position - rb.transform.position) * 50f;
        rb.velocity = velocity;       
    }
    public Vector3 GetVelocity() //getter function for getting the velocity
    {
        return velocity;
    }

    public void SetFollowTarget(BatCapsule batCapsule) //setting batcapsule to batfollower
    {
        batFollower = batCapsule;
    }
}
