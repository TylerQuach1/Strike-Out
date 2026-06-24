using TMPro;
using UnityEngine;

public class ActiveHand : MonoBehaviour //Script for setting active hand variables
{
    public GameObject leftHand;
    public GameObject rightHand;
    public GameObject cameraRig;
    public GameObject mainCanvas;
    public GameObject eventSystem;

    public TMP_Text buttonText;

    public void toggleHand() 
    {
        if (cameraRig.GetComponent<Handedness>().currentHand == rightHand) //if set right hand as current hand (enable selector, bat, disable grab capabilities)
        {
            buttonText.text = "Right";
            mainCanvas.GetComponent<Canvas>().worldCamera = rightHand.GetComponent<Camera>();
            rightHand.GetComponent<Selector>().enabled = true;
            rightHand.GetComponent<LineRenderer>().enabled = true;
            rightHand.GetComponent<Grab>().enabled = true;
            leftHand.GetComponent<Selector>().enabled = false;
            leftHand.GetComponent<LineRenderer>().enabled = false;
            leftHand.GetComponent<Grab>().enabled = false;
            eventSystem.GetComponent<VR_Input_Module>().handType = Valve.VR.SteamVR_Input_Sources.RightHand;
            eventSystem.GetComponent<VR_Input_Module>().handCamera = rightHand.GetComponent<Camera>();

        }
        else //if set left hand as current hand (enable selector, bat, disable grab capabilities)
        {
            buttonText.text = "Left";
            mainCanvas.GetComponent<Canvas>().worldCamera = leftHand.GetComponent<Camera>();
            rightHand.GetComponent<Selector>().enabled = false;
            rightHand.GetComponent<LineRenderer>().enabled = false;
            rightHand.GetComponent<Grab>().enabled = false;
            leftHand.GetComponent<Selector>().enabled = true;
            leftHand.GetComponent<LineRenderer>().enabled = true;
            leftHand.GetComponent<Grab>().enabled = true;
            eventSystem.GetComponent<VR_Input_Module>().handType = Valve.VR.SteamVR_Input_Sources.LeftHand;
            eventSystem.GetComponent<VR_Input_Module>().handCamera = leftHand.GetComponent<Camera>();
        }
    }
}
