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
	public Text Player1ScoreText;
	public Text Player2ScoreText;
	public Text WinText;

	// The score needed to win
	public int WinScore;

	/// Private variables

	// Player scores
	private int player1Score;
	private int player2Score;

	private bool isGamePlaying;


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
		WinText.enabled = false;
		isGamePlaying = false;

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

		// Start ball
		Ball.GetComponent<BallMovement>().StartBallMovement();

		isGamePlaying = true;
	}

	// Adds a point to player and resets the game
	public void AddScore(Player player)
	{
		// Adds score to player 1 and update text
		if (player == Player.Player1)
		{
			player1Score += 1;
			Player1ScoreText.text = player1Score.ToString();
		}
		// Adds score to player 2 and update text
		else
		{
			player2Score += 1;
			Player2ScoreText.text = player2Score.ToString();
		}

		CheckWin();
	}

	private void CheckWin()
	{
		// if player 1 wins
		if (player1Score == WinScore)
		{
			// Congratulate player 1
			ResetGame();
			WinText.text = "Player 1 Wins!";
			WinText.enabled = true;
		}

		// if player 2 wins
		else if (player2Score == WinScore)
		{
			// Congratulate player 2
			ResetGame();
			WinText.text = "Player 2 Wins!";
			WinText.enabled = true;
		}

		else if (isGamePlaying)
		{
			// Starts next round
			Ball.GetComponent<BallMovement>().ResetBall();
			StartGame();
		}
	}
}
