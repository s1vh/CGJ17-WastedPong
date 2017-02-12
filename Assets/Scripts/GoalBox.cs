using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBox : MonoBehaviour {

    GameManager gameManager;
    GameObject manager;
    public int goalNum = 1;

    // Set up references.
    void Awake()
    {
        manager = GameObject.Find("GameManager");
        gameManager = manager.GetComponent<GameManager>();
    }

    // Use this for initialization
    void Start ()
    {
		
	}

    // Update is called once per frame
    void Update ()
    {
		
	}

}
