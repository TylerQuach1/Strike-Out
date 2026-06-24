using UnityEngine;

public class strikeZone : MonoBehaviour//strike zone box script
{
    public GameObject PitchingCannon;
    public GameObject indicator;
    public GameObject Jumbotron;

    private void OnCollisionEnter(Collision other) //if ball collides with strike zone box collider
    {
        if(other.gameObject.tag == "ball")
        {
            Destroy(other.gameObject); //destroy ball
            Instantiate(indicator, other.transform.position , Quaternion.identity); //spawn in hit indicator
            Jumbotron.GetComponent<GameScore>().increaseStrikes(); //increase strike score
            PitchingCannon.GetComponent<PitchingCannon>().thrown = false; //set throw as false
        }
    }
}
