﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script manages the behavior of individual obstacle
public class Obstacle : MonoBehaviour
{
    [SerializeField] private float Speed = 3;
    private int score;
    public GameObject player;

    void Start()
    {
        PlayerPrefs.SetInt("Score",score = 0);
        player = GameObject.Find("AngryDuck");
    }

    void Update()
    {
        if (transform.position.x <= -7)
        {
            addScore();
            Destroy(gameObject);
        }
        else
        {
            transform.Translate(Vector3.right * Time.deltaTime * -Speed);
        }
    }
    public void addScore()
    {
        score++;
        PlayerPrefs.SetInt("Score", score);
    }

}
