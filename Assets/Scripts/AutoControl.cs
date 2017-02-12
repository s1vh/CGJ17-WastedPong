using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoControl : MonoBehaviour {

    GameManager gameManager;
    GameObject manager;
    [SerializeField]
    GameObject ball;
    [SerializeField]
    float size;
    Rigidbody2D racketBody;

    // Set up references.
    void Awake()
    {
        manager = GameObject.Find("GameManager");
        gameManager = manager.GetComponent<GameManager>();
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
        if(gameManager.gameState == 1)
        {
            racketBody.velocity = new Vector2(0f, (ball.transform.position.y - this.transform.position.y) * gameManager.racketSpeed);
        }
    }
}
