using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoControl : MonoBehaviour {

    public bool rightSide = false;

    GameManager gameManager;
    GameObject manager;
    BallBehaviour ballBehaviour;
    GameObject ball;
    [SerializeField]
    float size;
    Rigidbody2D racketBody;

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
            racketBody.velocity = new Vector2(0f, (ball.transform.position.y - this.transform.position.y) * gameManager.racketSpeed);
        }
        else if(rightSide && gameManager.gameState == 1 && ballBehaviour.CheckRightDirection() >= 0)
        {
            racketBody.velocity = new Vector2(0f, (ball.transform.position.y - this.transform.position.y) * gameManager.racketSpeed);
        }
    }
}
