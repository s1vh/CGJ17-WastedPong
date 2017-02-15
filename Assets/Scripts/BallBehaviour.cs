using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour {

    public int maxBounces = 16;

    private GameManager gameManager;
    private GameObject manager;
    private PlayerControl playerControl;
    private GameObject player;
    private Rigidbody2D ballBody;
    private Transform ballTransform;
    private Renderer ballRender;
    private Vector2 direction;
    [SerializeField]
    private int bounces;

    // Set up references.
    void Awake()
    {
        manager = GameObject.Find("GameManager");
        gameManager = manager.GetComponent<GameManager>();
        player = GameObject.Find("PalaPlayer");
        playerControl = player.GetComponent<PlayerControl>();
        ballTransform = GetComponent<Transform>();
        ballBody = GetComponent<Rigidbody2D>();
        ballRender = GetComponentInChildren<Renderer>();
    }

    // Use this for initialization
    void Start ()
    {
        bounces = 0;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.tag)
        {
            case "Player":
                if (bounces < maxBounces) { bounces++; }
                direction = new Vector2(-direction.x, direction.y);
                ApplyVelocity();
                break;
            case "Wall":
                direction = new Vector2(direction.x, -direction.y);
                ApplyVelocity();
                break;
            case "Goal":
                ballBody.velocity = new Vector2(0f, 0f);
                //ResetBall();
                ballRender.enabled = false;
                gameManager.Scoring(col.gameObject.GetComponent<GoalBox>().goalNum);
                Debug.Log("Goal! " + col.gameObject.GetComponent<GoalBox>().goalNum);
                break;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Respawn")
        {
            playerControl.TurnPlayerOn(true);
        }
    }

    // Update is called once per frame
    void Update ()
    {
		
	}

    float RandomSign(float num)
    {
        int sign = -1;
        int i = Random.Range(1, 3);
        while (i > 0)
        {
            i--;
            sign = sign * -1;
        }
        return num * sign;
    }

    void ResetBall()
    {
        bounces = 0;
        ballTransform.position = new Vector3(0f, Random.Range(-4f, 4f), 0f);
    }

    void ApplyVelocity ()
    {
        ballBody.velocity = direction * (gameManager.ballSpeed + bounces * 0.1f);
    }

    public void LaunchBall()
    {
        ResetBall();
        ballRender.enabled = true;
        direction = new Vector2(RandomSign(4f), RandomSign(4f));
        ApplyVelocity();
    }

    public float CheckRightDirection()
    {
        /*
        if(ballBody.velocity.x > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
        */
        return ballBody.velocity.x;
    }
}
