using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityStandardAssets.CrossPlatformInput;

public class PlayerControl : MonoBehaviour {

    private GameManager gameManager;
    private GameObject manager;
    private Rigidbody2D racketBody;
    private Collider2D playerCollider;
    private float input;

    // Set up references.
    void Awake()
    {
        manager = GameObject.Find("GameManager");
        gameManager = manager.GetComponent<GameManager>();
        racketBody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (playerCollider.enabled)
        {
            input = Input.GetAxis("Vertical");
        }
        else
        {
            input = 0;
        }
        //Debug.Log(input);
    }

    void FixedUpdate ()
    {
        racketBody.velocity = new Vector2(0f, input * gameManager.racketSpeed * 2);
    }

    public void TurnPlayerOn(bool on)
    {
        if(on && !playerCollider.enabled)
        {
            playerCollider.enabled = true;
        }
        else if (!on && playerCollider.enabled)
        {
            playerCollider.enabled = false;
        }
    }

}
