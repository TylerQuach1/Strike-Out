using UnityEngine;

public class ballZone : MonoBehaviour //Script for detecting if batter swings at invalid balls to increase ball score
{
    //Varibles for various gameobjects
    public GameObject ballZoneArea;
    public GameObject player;
    public GameObject Jumbotron;
    public GameObject pitchingCannon;

    private bool swing = false;
    private void OnTriggerEnter(Collider other) //If ball goes through the ballZone collider then determine if player swung and increase strike or ball
    {
        if (other.gameObject.tag == "ball" && other.gameObject != null) //if the game object is a ball and exists
        {
            pitchingCannon.GetComponent<PitchingCannon>().valid = false; //set pitch to being invalid as a strike 
            if (pitchingCannon.GetComponent<PitchingCannon>().baseball.GetComponent<Ball>().ballHit) //if ball is hit and ends up in the ball zone count as foul (do nothing)
            {

            }
            else if (swing) //if player swings when the ball goes past the strike zone then a strike is commited
            {
                Jumbotron.GetComponent<GameScore>().increaseStrikes();
            }
            else //if player dosnt swing increase ball score
            {
                Jumbotron.GetComponent<GameScore>().increaseBall();
            }
            if (!other.gameObject.GetComponent<Ball>().ballDestroy) //if the ball is not being destroyed then activate destroy function
            {
                StartCoroutine(other.gameObject.GetComponent<Ball>().DestroyBall());
            }
        }
    }

    void Update()
    {
        if (pitchingCannon.GetComponent<PitchingCannon>().thrown) //if ball is thrown
        {
            if (player.GetComponent<Handedness>().PlayerBat != null && !swing) //check if player has swung based on the top(fastest) batCapsule velocity
            {
               
                swing = (player.GetComponent<Handedness>().PlayerBat.transform.GetChild(1).GetComponent<BatCapsule>().follower.GetVelocity().magnitude > 10.0f);

            }
        }
        else
        {
            swing = false;
        }
    }
}
