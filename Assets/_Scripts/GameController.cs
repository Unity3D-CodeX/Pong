using UnityEngine;
using UnityEngine.UI;

public enum Player
{
	Player1,
	Player2
}

public enum PlayerPart
{
	Upper,
	Middle,
	Lower
}

public class GameController : MonoBehaviour
{
	/// Public variables
	
	// Game objects with physics
	public GameObject[] Players;
	public GameObject[] Borders;
	public GameObject Ball;

	// UI game objects
	public GameObject Player1ScoreText;
	public GameObject Player2ScoreText;

	/// Private variables

	// Player scores
	private int player1Score;
	private int player2Score;


	// Use this for initialization
	void Start ()
	{
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
		// Adds score to player 1 and update text
		if (player == Player.Player1)
		{
			player1Score += 1;
			Player1ScoreText.GetComponent<Text>().text = player1Score.ToString();
		}
		// Adds score to player 2 and update text
		else
		{
			player2Score += 1;
			Player2ScoreText.GetComponent<Text>().text = player2Score.ToString();
		}

		// Starts next round
		ResetBall();
		StartGame();
	}
}
