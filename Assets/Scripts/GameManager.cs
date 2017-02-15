using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static int level;
    public int gameState;
    public float racketSpeed;
    public float ballSpeed;
    public float timer;
    public int playerScore;

    private BallBehaviour ballBehaviour;
    private GameObject ball;
    private GameObject[] rackets;
    private PlayerControl playerControl;
    private GameObject player;
    [SerializeField]
    private int goalCap = 9;
    private int scoreGoal1;
    private int scoreGoal2;
    private int score1;
    private int score2;
    private bool reset;

    // Set up references.
    void Awake()
    {
        ball = GameObject.Find("Ball");
        ballBehaviour = ball.GetComponent<BallBehaviour>();
        player = GameObject.Find("PalaPlayer");
        playerControl = player.GetComponent<PlayerControl>();
        rackets = GameObject.FindGameObjectsWithTag("Player");
    }

    // Use this for initialization
    void Start ()
    {
        level = 1;
        racketSpeed = 1;
        ballSpeed = 1;
        timer = 0;
        playerScore = 0;
        gameState = 0;
        reset = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
        //Debug.Log("GameState:" + gameState);
        switch (gameState)
        {
            // START
            case 0:
                if (Input.GetButtonUp("Jump"))
                {
                    // Reset
                    if (reset)
                    {
                        score1 = 0;
                        score2 = 0;
                        scoreGoal1 = 0;
                        scoreGoal2 = 0;
                        while (scoreGoal1 == 0 && scoreGoal2 == 0)
                        {
                            scoreGoal1 = Random.Range(0, goalCap);
                            scoreGoal2 = Random.Range(0, goalCap);
                        }
                        reset = false;
                        Debug.Log("Score Goal 1: " + scoreGoal1);
                        Debug.Log("Score Goal 2: " + scoreGoal2);
                    }
                    foreach (GameObject racket in rackets)
                    {
                        racket.transform.position = new Vector3(racket.transform.position.x, 0f, racket.transform.position.z);
                    }
                    ballBehaviour.LaunchBall();
                    gameState = 1;
                    Debug.Log("Start");
                }
                break;
        }
	}

    public void Scoring(int door)
    {
        gameState = 0;      // Stop
        if(ballSpeed < 10)
        {
            ballSpeed = ballSpeed + 0.5f;
            racketSpeed = racketSpeed + 0.5f;
        }
        switch (door)
        {
            case 1:
                score1++;
                playerControl.TurnPlayerOn(false);
                Debug.Log("Score 1: " + score1);
                if (score1 > scoreGoal1)    // Check score overflow
                {
                    reset = true;
                    Debug.Log("Overflow! Reseting... ");
                }
                break;
            case 2:
                score2++;
                playerControl.TurnPlayerOn(false);
                Debug.Log("Score 2: " + score2);
                if (score2 > scoreGoal2)    // Check score overflow
                {
                    reset = true;
                    Debug.Log("Overflow! Reseting... ");
                }
                break;
        }
        // Check win condition
        if (score1 == scoreGoal1 && score2 == scoreGoal2)
        {
            if (level <= 10)
            {
                level++;
                ballSpeed = 1;
                playerScore++;  // balancear en base al tiempo
                Debug.Log("Sucess! Starting level " + level);
                foreach(GameObject racket in rackets)
                {
                    racket.transform.localScale = new Vector3(1f, 11-level, 1f);
                }
            }
            else
            {
                gameState = -1;
                Debug.Log("You win!");
            }
        }
    }
}
