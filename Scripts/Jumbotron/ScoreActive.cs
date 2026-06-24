using UnityEngine;

public class ScoreActive : MonoBehaviour //Script for indicator children
{
    public bool activated;

    private Material active;
    private Material inactive;

    private void Awake() //on awake set indicator materials
    {
        active = GetComponentInParent<ParentIndicator>().activeMat;
        inactive = GetComponentInParent<ParentIndicator>().inactiveMat;
    }

    void Update() //if indicator is activated then show resulting material to represent game state
    {
        if (activated)
        {
            this.gameObject.GetComponent<MeshRenderer>().material = active;
        }
        else
        {
            this.gameObject.GetComponent<MeshRenderer>().material = inactive;
        }
    }
}
