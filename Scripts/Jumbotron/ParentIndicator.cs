using System.Collections.Generic;
using UnityEngine;

public class ParentIndicator : MonoBehaviour //Script for handling jumbotron score indicators
{
    public List<GameObject> children;
    public Material activeMat;
    public Material inactiveMat;

    public int score;
    void Start() //on spawn add indicators children to a list
    {

        foreach (Transform tr in GetComponentsInChildren<Transform>())
        {
            children.Add(tr.gameObject);
        }
        children.RemoveAt(0);
    }

    void Update() //if indicator score is update then activate/deactivate children to represent game state
    {
        for (int i = 0; i < children.Count; i++)
        {
            if(score > i)
            {
                children[i].GetComponent<ScoreActive>().activated = true;
            }
            else
            {
                children[i].GetComponent<ScoreActive>().activated = false;
            }
            
        }
       
    }
}
