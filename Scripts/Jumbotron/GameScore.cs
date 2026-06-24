using UnityEngine;

public class GameScore : MonoBehaviour //Script for handling game score state
{
    private int Out;
    private int Ball;
    private int Strikes;
    public int Runs;
    public GameObject StrikeIndicator;
    public GameObject BallIndicator;
    public GameObject OutIndicator;
    public GameObject inningSound;
    public GameObject crowdSound;
    public GameObject baseballDiamond;

    void Start() //start the game resetting all the scores
    {
        resetOut();
        resetBall();
        resetStrike();
        resetRuns();
    }

    void Update() //update scoreboard with current scores
    {
        StrikeIndicator.GetComponent<ParentIndicator>().score = Strikes;
        BallIndicator.GetComponent<ParentIndicator>().score = Ball;
        OutIndicator.GetComponent<ParentIndicator>().score = Out;

        if(Strikes == 3) //if 3 strikes then batter is out 
        {
            increaseOut(); //increase out
            if(Out < 3)
            {
                inningSound.GetComponent<InningAudio>().playRandominning(); //play sound to signify new batter
            }
            resetBall();
            resetStrike(); 
        }
        if (Out == 3) //if 3 outs then game resets
        {
            resetOut();
            resetBall();
            resetStrike();
            resetRuns();
            baseballDiamond.GetComponent<RunnerState>().resetRunners();
            baseballDiamond.GetComponent<RunnerState>().updateScoreText();//reset score
        }
        if(Ball == 4) //if 4 balls then batter gets a free run to first base
        {
            baseballDiamond.GetComponent<RunnerState>().walk();
        }
    }

    public void increaseOut()
    {
        Out = Out + 1;
    }
    public void increaseBall()
    {
        Ball = Ball + 1;
    }
    public void increaseStrikes()
    {
        crowdSound.GetComponent<CrowdAudio>().playSad();
        Strikes = Strikes + 1;
    }

    public void resetOut()
    {
        Out = 0;
    }
    public void resetBall()
    {
        Ball = 0;
    }

    public void resetStrike()
    {
        Strikes = 0;
    }
    public void resetRuns()
    {
        Runs = 0;
    }


}
