using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour {

    GameManager gameManager;
    GameObject manager;
    Rigidbody2D ballBody;
    Transform ballTransform;
    Vector2 direction;

    // Set up references.
    void Awake()
    {
        manager = GameObject.Find("GameManager");
        gameManager = manager.GetComponent<GameManager>();
        ballTransform = GetComponent<Transform>();
        ballBody = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start ()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.tag)
        {
            case "Player":
                direction = new Vector2(-direction.x, direction.y);
                ApplyVelocity();
                break;
            case "Wall":
                direction = new Vector2(direction.x, -direction.y);
                ApplyVelocity();
                break;
            case "Goal":
                Reset();
                gameManager.Scoring(col.gameObject.GetComponent<GoalBox>().goalNum);
                Debug.Log("Goal! " + col.gameObject.GetComponent<GoalBox>().goalNum);
                break;
        }
    }

    // Update is called once per frame
    void Update ()
    {
		
	}

    void ApplyVelocity ()
    {
        ballBody.velocity = direction * gameManager.ballSpeed;
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
        return num*sign;
    }

    public void LaunchBall()
    {
        direction = new Vector2(RandomSign(4f), RandomSign(4f));
        ApplyVelocity();
    }

    public void Reset()
    {
        ballBody.velocity = new Vector2(0f, 0f);
        ballTransform.position = new Vector3(0f, 0f, 0f);
    }
}
