using TMPro;
using UnityEngine;

public class PitchingCannon : MonoBehaviour //Script for handling pitcher and ball state
{
    public GameObject baseballPrefab;
    public GameObject pitcherHand;
    public float ReadyTimer; //after certain time of being ready throw pitch
    public GameObject player;
    public Camera BallCamera;
    public TextMeshPro ballStats;
    public float ballDistance;
    public GameObject baseball;
    public GameObject crowdSound;
    public bool thrown;
    public bool valid;
 
    private Vector3 intialVelocity;

    private GameObject offHand;
    
    private bool pitching;
    private float startTimer = 0.0f;
    private float throwTimer;
    private float ballSpeed;
    private bool cheer;
    private void Start() //set off hand as right hand by default
    {
        offHand = player.GetComponent<Handedness>().rightHand;
    }

    private void Update()
    {
        if (pitching) //if pitcher currently ready to pitch indicate green
        {
            pitcherHand.GetComponent<MeshRenderer>().material.color = Color.green;
        }
        else if (thrown) //if ball thrown then indicate red
        {
            pitcherHand.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        else //if in no state indicate white
        {
            pitcherHand.GetComponent<MeshRenderer>().material.color = Color.white;
        }


        if (offHand.GetComponent<Grab>().ready && !thrown) //if ball is not thrown and batter is ready
        {
            if (!pitching) //if not already pitching
            {
                throwTimer = UnityEngine.Random.Range(3.5f, 6.0f); //get random time for pitcher throw
                pitching = true;
            }
            else
            {
                if (throwTimer < startTimer) //if startTimer surpasses throwTimer then throw ball
                {
                    Throw();
                }
                startTimer += Time.deltaTime;//increase timer
            }
        }
        else
        {
            startTimer = 0.0f; //reset timer and pitch
            pitching = false; 
        }

        if (baseball != null) //if there is a baseball
        {
            if (baseball.GetComponent<Ball>().ballHit) //and the baseball has been hit, track the ball
            {
                if (ballSpeed < BallCamera.velocity.magnitude) //if speed increasing set topspeed
                {
                    ballSpeed = BallCamera.velocity.magnitude;
                }
                if (!cheer) //if crowd not cheering then cheer after hit
                {
                    crowdSound.GetComponent<CrowdAudio>().playHappy();
                    cheer = true;
                }
                BallCamera.transform.position = baseball.transform.position + BallCamera.transform.forward * -0.5f + BallCamera.transform.up * 0.2f; //track ball
                BallCamera.transform.LookAt(new Vector3(0f, 0f, 0f)); //look at player 
                ballDistance = Vector3.Distance(baseball.transform.position, player.transform.position); 
                ballStats.text = string.Format("Hit!! <br>Speed: {0} <br>Distance: {1}", ballSpeed, ballDistance); //update jumbotron message
                
            }
        }
        else //reset varibles and camera
        {
            cheer = false;
            valid = true;
            ballSpeed = 0f;
            BallCamera.transform.position = new Vector3(1.7f, 1f, 1.7f);
            BallCamera.transform.rotation = (Quaternion.Euler(0f, -135f, 0f));
            thrown = false;
        }
    }
    
    public void getOffHand() //get off hand
    {
        Handedness script = player.GetComponent<Handedness>();
        if (script.currentHand == script.rightHand)
        {
            offHand = script.rightHand;
        }
        else {
            offHand = script.leftHand;
        }
    }

    private void Throw() //throw function
    {
        if (pitching) // if pitcher pitching
        {
            baseball = Instantiate(baseballPrefab, pitcherHand.transform.position, Quaternion.identity); //spawn ball
            Rigidbody rb = baseball.GetComponent<Rigidbody>(); 
            float throwPower = (UnityEngine.Random.Range(15f, 18f));
            float offsetPower = 0.5f;
            intialVelocity = new Vector3(UnityEngine.Random.Range(throwPower - offsetPower, throwPower + offsetPower), UnityEngine.Random.Range(3f, 4f), UnityEngine.Random.Range(throwPower - offsetPower, throwPower + offsetPower));
            rb.AddForce(intialVelocity, ForceMode.Impulse); //add impulse force to ball
            ballStats.text = string.Format("Pitch <br>Speed: {0} <br>", intialVelocity.magnitude); //update jumbotron message
            pitching = false;
            thrown = true;
        }
    }
   
}
