using UnityEngine;
using UnityEngine.EventSystems;
using Valve.VR;

public class VR_Input_Module : BaseInputModule //Script for vr input for canvas
{

    public Camera handCamera;
    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean clickAction;

    private GameObject CurrentObject;
    private PointerEventData Data;

    protected override void Awake() //on awake set data as a pointer event for a event system
    {
        base.Awake();

        Data = new PointerEventData(eventSystem);
    }

    public override void Process() //process controller hovering point from camera
    {

        //Reset data, set camera
        Data.Reset();
        Data.position = new Vector2(handCamera.pixelWidth / 2, handCamera.pixelHeight / 2);

        //Raycast
        eventSystem.RaycastAll(Data, m_RaycastResultCache);
        Data.pointerCurrentRaycast = FindFirstRaycast(m_RaycastResultCache);
        CurrentObject = Data.pointerCurrentRaycast.gameObject;

        //Clear
        m_RaycastResultCache.Clear();

        //Hover
        HandlePointerExitAndEnter(Data, CurrentObject);

        //Press
        if (clickAction.GetStateDown(handType))
        {
            ProcessPress(Data);
        }

        //Release

        if (clickAction.GetStateUp(handType))
        {
            ProcessRelease(Data);
        }

    }

    public PointerEventData GetData() 
    { 
        return Data; 
    }

    private void ProcessPress(PointerEventData data) //handle controller button press
    {
        data.pointerPressRaycast = data.pointerCurrentRaycast;

        GameObject newPointerPress = ExecuteEvents.ExecuteHierarchy(CurrentObject, data, ExecuteEvents.pointerDownHandler);

        if (newPointerPress == null) 
        {
            newPointerPress = ExecuteEvents.GetEventHandler<IPointerClickHandler>(CurrentObject);
        }

        data.pressPosition = data.position;
        data.pointerPress = newPointerPress;
        data.rawPointerPress = CurrentObject;

    }

    private void ProcessRelease(PointerEventData data) //handle controller button release
    {
        ExecuteEvents.Execute(data.pointerPress, data, ExecuteEvents.pointerUpHandler);

        GameObject pointerUpHandler = ExecuteEvents.GetEventHandler<IPointerClickHandler>(CurrentObject);

        if(data.pointerPress == pointerUpHandler)
        {
            ExecuteEvents.Execute(data.pointerPress, data, ExecuteEvents.pointerClickHandler);
        }

        eventSystem.SetSelectedGameObject(null);

        data.pressPosition = Vector2.zero;
        data.pointerPress = null;
        data.rawPointerPress =null;

    }

}
