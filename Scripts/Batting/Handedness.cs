using System.Collections;
using UnityEngine;
using Valve.VR;


public class Handedness : MonoBehaviour //Script that handles the players prefered hand state
{
    //Varibles for setting/determing hand state
    public GameObject leftHand;
    public GameObject rightHand;
    public GameObject bat;

    private Rigidbody hand;
    public GameObject PlayerBat;
    public GameObject currentHand;

    private void Awake()//on spawn set right hand as the default hand
    {
        currentHand = rightHand;
        hand = leftHand.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()//during game loop if there is no player bat spawn bat in prefered hand
    {
        if(PlayerBat != null)
        {
            PlayerBat.transform.position = hand.transform.position;
            PlayerBat.transform.rotation = hand.transform.rotation;
        }
    }

    public void SpawnBat() //spawns bat at prefered hand and disables selector for menu and moves player to corresponding batting box
    {
        currentHand.GetComponent<LineRenderer>().enabled = false;
        PlayerBat = Instantiate(bat);
        if (currentHand == leftHand)
        {
            StartCoroutine(TeleportFade(new Vector3(-0.2f, 0.05f, 0.7f), new Vector3(0, 135f, 0f)));
        }
        if(currentHand == rightHand)
        {
            StartCoroutine(TeleportFade(new Vector3(0.7f, 0.05f, -0.2f), new Vector3(0, -45f, 0f)));
        }
    }

    public void SwitchHandedness() //accessible from options menu for toggling handedness
    {
        if(currentHand == leftHand)
        {
            currentHand = rightHand;
            hand = leftHand.GetComponent<Rigidbody>();
        }
        else
        {
            currentHand = leftHand;
            hand = rightHand.GetComponent<Rigidbody>();
        }
    }

    private IEnumerator TeleportFade(Vector3 pos, Vector3 rotation) //teleport camera rig to batter box and fade in and out of darkness to reduce motion sickness
    {
        SteamVR_Fade.View(Color.black, 0.5f);
        yield return new WaitForSeconds(0.7f);
        this.gameObject.transform.position = pos;
        this.gameObject.transform.rotation = (Quaternion.Euler(rotation));

        SteamVR_Fade.View(Color.clear, 0.5f);

    }
}
