using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoControl : MonoBehaviour {

    public bool rightSide = false;

    private GameManager gameManager;
    private GameObject manager;
    private BallBehaviour ballBehaviour;
    private GameObject ball;
    private Rigidbody2D racketBody;

    // Set up references.
    void Awake()
    {
        manager = GameObject.Find("GameManager");
        gameManager = manager.GetComponent<GameManager>();
        ball = GameObject.Find("Ball");
        ballBehaviour = ball.GetComponent<BallBehaviour>();
        racketBody = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    void FixedUpdate ()
    {
        if(!rightSide && gameManager.gameState == 1 && ballBehaviour.CheckRightDirection() <= 0)
        {
            racketBody.velocity = new Vector2(0f, (ball.transform.position.y - this.transform.position.y) * gameManager.racketSpeed * Mathf.Sqrt(2));
        }
        else if(rightSide && gameManager.gameState == 1 && ballBehaviour.CheckRightDirection() >= 0)
        {
            racketBody.velocity = new Vector2(0f, (ball.transform.position.y - this.transform.position.y) * gameManager.racketSpeed);
        }
    }

}
