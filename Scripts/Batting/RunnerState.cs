using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RunnerState : MonoBehaviour //handle runner state after hitting a ball
{
    public List<GameObject> Runners; //list of all runners

    public float ballDistance;
    public GameObject PitchingCannon;
    public GameObject runnerPrefab;
    public GameObject jumboTron;
    public TextMeshPro score;
    public GameObject inningSound;

    private GameObject baseball;
    private bool validBall;
    private GameObject runner;
    void Update() 
    {
        if(PitchingCannon.GetComponent<PitchingCannon>().baseball != null) { //if pitch is thrown

            baseball = PitchingCannon.GetComponent<PitchingCannon>().baseball;
            //if the baseball has been hit and stopped get the distance of the ball and access situation
            if (baseball.GetComponent<Ball>().ballHit && baseball.GetComponent<Ball>().ballStop && PitchingCannon.GetComponent<PitchingCannon>().valid) 
            {
               validBall = true;
            }
        }
        else //when ball is destroyed
        {
            if (validBall) //if ball hit into a valid area of the map
            {
                ballDistance = PitchingCannon.GetComponent<PitchingCannon>().ballDistance; //get the ball distance 
                if (ballDistance > 300) //home run
                {
                    spawnRunner();
                    updateBase(Runners, 5);
                    resetBatterCounts();
                }
                else if (ballDistance > 200) //triple
                {
                    spawnRunner();
                    updateBase(Runners, 3);
                    resetBatterCounts();
                }
                else if (ballDistance > 150) //double
                {
                    spawnRunner();
                    updateBase(Runners, 2);
                    resetBatterCounts();
                }
                else if (ballDistance > 100) //single
                {
                    spawnRunner();
                    updateBase(Runners, 1);
                    resetBatterCounts();
                }
                else if (ballDistance < 100) //out
                {
                    jumboTron.GetComponent<GameScore>().increaseOut();
                    resetBatterCounts();
                    inningSound.GetComponent<InningAudio>().playRandominning();
                }
                validBall = false;
            }
        }
    }

    public void walk() //if player scores a walk all batters advance
    {
        spawnRunner();
        updateBase(Runners, 1);
        resetBatterCounts();
    }

    private void resetBatterCounts() 
    {
        jumboTron.GetComponent<GameScore>().resetStrike();
        jumboTron.GetComponent<GameScore>().resetBall();
    }
    private void spawnRunner() //spawn the runner with a random color
    {
        runner = Instantiate(runnerPrefab, new Vector3(0, -2f, 0), Quaternion.identity);
        runner.GetComponent<MeshRenderer>().material.color = UnityEngine.Random.ColorHSV();
        Runners.Add(runner);
    }
    public void updateScoreText()
    {
        score.text = string.Format("{0}", jumboTron.GetComponent<GameScore>().Runs);
    }

    private void updateBase(List<GameObject> runnerList, int bases) //handle the bases when a ball was struck, increasing the bases of all batters
    {
        List < GameObject > removeRunners = new List < GameObject >();
        foreach (GameObject runner in runnerList) {
            runner.GetComponent<Runner>().increaseBase(bases);
            if (runner.GetComponent<Runner>().atBase > 3 )  //if runner passes 4th base increase a run
            {
                jumboTron.GetComponent<GameScore>().Runs += 1;
                score.text = string.Format("{0}", jumboTron.GetComponent<GameScore>().Runs);
                runner.GetComponent<Renderer>().enabled = false;
                removeRunners.Add(runner);
            }
        }

        foreach (GameObject runner in removeRunners) //remove runner from list
        {
            runnerList.Remove(runner);
            Destroy(runner);
        }
    }

    public void resetRunners()
    {
        foreach (GameObject runner in Runners) //remove all runners
        {
            Destroy(runner);
        }
        Runners.Clear();
    }
}
