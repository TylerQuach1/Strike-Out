using UnityEngine;
using UnityEngine.EventSystems;
using Valve.VR;

public class Selector : MonoBehaviour //Script for handling ui selector
{
    public SteamVR_Input_Sources handType;
    public GameObject hand;
    public float length;
    public VR_Input_Module inputModule;

    private LineRenderer laserLine;

    void Start() //get laserline from prefered hand
    {
        laserLine = hand.GetComponent<LineRenderer>();
    }

    void Update() 
    {

        PointerEventData data = inputModule.GetData(); //input data from canvas

        float currentLength = data.pointerCurrentRaycast.distance == 0 ? length : data.pointerCurrentRaycast.distance; //if length from pointer to ui canvas

        Vector3 rayOrigin = hand.transform.position;

        laserLine.SetPosition(0, rayOrigin);

        RaycastHit hit;

        if (Physics.Raycast(rayOrigin, hand.transform.forward, out hit, currentLength))
        {

            laserLine.SetPosition(1, hit.point); //set position to ui hit point

        }
        else
        {
            laserLine.SetPosition(1, transform.position + hand.transform.forward* currentLength); //set position to max distance
        }
  
    }
}
