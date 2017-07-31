using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Player
{
	Player1,
	Player2
}

public class GameController : MonoBehaviour
{
	/// Private variables

	// Player scores
	private int player1Score;
	private int player2Score;

	// Game objects
	private GameObject[] Players;
	private GameObject[] Borders;
	private GameObject Ball;

	// Use this for initialization
	void Start ()
	{
		// Get game objects
		Players = GameObject.FindGameObjectsWithTag("Player");
		Borders = GameObject.FindGameObjectsWithTag("Border");
		Ball = GameObject.FindGameObjectWithTag("Ball");

		ResetGame();
		StartGame();
	}

	// Resets the whole game
	private void ResetGame()
	{
		player1Score = 0;
		player2Score = 0;
		ResetBall();
	}

	// Resets paddles and the ball
	private void ResetBall()
	{
		// Reset ball
		Ball.GetComponent<BallMovement>().ResetBall();
	}

	private void StartGame()
	{
		// Reset Paddles
		for (int i = 0; i < Players.Length; i++)
		{
			Players[i].GetComponent<PaddleMovement>().StartGame();
		}

		// Reset ball
		Ball.GetComponent<BallMovement>().StartBallMovement();
	}

	// Adds a point to player and resets the game
	public void AddScore(Player player)
	{
		// Adds score to player 1
		if (player == Player.Player1)
		{
			player1Score += 1;
		}
		// Adds score to player 2
		else
		{
			player2Score += 1;
		}

		// Starts next round
		ResetBall();
		StartGame();
	}
}
