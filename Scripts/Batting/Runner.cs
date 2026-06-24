using UnityEngine;

public class Runner : MonoBehaviour //Script for handling batter state after making a run
{
    public int atBase; //current batter position

    void Update() //move player to each plate
    {
        if (atBase == 1){
            this.gameObject.transform.position = new Vector3 (-24.1f, 1 , 0.1f);
        }
        else if(atBase == 2) {
            this.gameObject.transform.position = new Vector3(-24.1f, 1, -24.1f); ;
        }
        else if (atBase == 3){
            this.gameObject.transform.position = new Vector3(0.1f, 1, -24.1f); ;
        }
    }

    public void increaseBase(int bases)//increase plate
    {
        atBase += bases;
    }
}
