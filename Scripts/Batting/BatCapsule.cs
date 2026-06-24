using UnityEngine;

public class BatCapsule : MonoBehaviour //Script for Capsules which tie to the bat
{

    public BatCapsuleFollower batCapsuleFollowerPrefab; //prefab
    public BatCapsuleFollower follower; //spawned in prefab
    private void SpawnBatCapsuleFollower()  //spawn capsule prefab set to follow current capsule 
    {
        follower = Instantiate(batCapsuleFollowerPrefab);
        follower.SetFollowTarget(this);
    }

    private void Start() //spawn capsule on start
    {
        SpawnBatCapsuleFollower();
    }

    private void Update() //update follower position to current capsule postion
    {
        follower.transform.position = transform.position;
        follower.transform.rotation = transform.rotation;
    }

}