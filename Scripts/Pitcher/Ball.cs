using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour //Ball prefab script
{
    Rigidbody ball;
    public bool ballStop = false;
    public bool ballHit = false;
    public bool ballDestroy = false;

    private void Awake() //on spawn set rigid body as ball
    {
        ball = GetComponent<Rigidbody>();
    }

    void Update() 
    {
        if (ball.velocity.magnitude <= 0.15f && !ballStop && !ballDestroy) //if ball is slower than 0.15f and ball not previously considered stoped/destroyed then set it as stoped and destroyed
        {
            ballStop = true;
            StartCoroutine(DestroyBall());
        }
    }

    public IEnumerator DestroyBall()//destroy ball coroutine
    {
        ballDestroy = true;
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }
}
