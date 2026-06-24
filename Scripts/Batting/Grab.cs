using UnityEngine;
using Valve.VR;


public class Grab : MonoBehaviour //Script for detecting if player is grabbing bat
{
    //initialize controlers and asset varibles
    public SteamVR_Input_Sources handType;
    public Transform controller;
    public SteamVR_Action_Boolean grabAction;
    public bool ready;

    private GameObject handle;

    private void OnTriggerEnter(Collider other) //if controller enters the handle set handle as collider
    {
        if (other.tag == "Grabbable")
        {
            handle = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other) //if controller exits an object then unset handle
    {
        if (other.tag == "Grabbable")
        {
            handle = null;
          
        }
    }

    void Update()  //if player presses grab button while in handle then set player to ready
    {
        if (grabAction.GetState(handType) && handle != null)
        {
           ready = true; 
           //if player hands are not align then the bat will tilt making swings less accurate during swing (sets rotation as interpolation between both controllers)
           handle.transform.parent.gameObject.transform.rotation = UnityEngine.Quaternion.Slerp(controller.rotation, handle.transform.parent.gameObject.transform.rotation, 0.5f);
        }
        else
        {
            ready = false;
        }
    }
}