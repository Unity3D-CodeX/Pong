using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public enum Player
{
	Player1,
	Player2,
	Player3,
	Player4
}

public enum BallDirection
{
	UpperRight,
	UpperLeft,
	LowerLeft,
	LowerRight,
	NoDebugDirection
}

public class GameController : MonoBehaviour
{
	/// Public variables

	// Game objects with physics
	public GameObject Ball;
	public GameObject[] Players;

	// UI game objects
	public Text[] PlayerScoreTexts;
	public Text WinText;
	public GameObject GoStart;

	// The score needed to win
	public int WinScore;

	/// Private variables

	// Player scores
	private int[] playerScores;

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
		// initialise the player scores
		playerScores = new int[Players.Length];
		for (int i = 0; i < Players.Length; i++)
		{
			playerScores[i] = 0;
		}

		WinText.enabled = false;
		GoStart.SetActive(false);
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
            playerScores[0] += 1;
            PlayerScoreTexts[0].text = playerScores[0].ToString();
        }

        // Adds score to player 2 and update text
        else if (player == Player.Player2)
        {
            playerScores[1] += 1;
            PlayerScoreTexts[1].text = playerScores[1].ToString();
        }

        // Adds score to player 3 and update text
        else if (Players.Length > 2 && player == Player.Player3)
        {
            playerScores[2] += 1;
            PlayerScoreTexts[2].text = playerScores[2].ToString();
        }

        // Adds score to player 4 and update text
        else if (Players.Length > 3 && player == Player.Player4)
        {
            playerScores[3] += 1;
            PlayerScoreTexts[3].text = playerScores[3].ToString();
        }
    }

	public void CheckWin()
	{
		// if player 1 wins
		if (playerScores[0] == WinScore)
		{
			// Congratulate player 1
			ResetGame();
			WinText.text = "Player 1 Wins!";
			WinText.enabled = true;
			GoStart.SetActive(true);
		}

		// if player 2 wins
		else if (playerScores[1] == WinScore)
		{
			// Congratulate player 2
			ResetGame();
			WinText.text = "Player 2 Wins!";
			WinText.enabled = true;
			GoStart.SetActive(true);
		}

		// if player 3 wins
		else if (Players.Length > 2 && playerScores[2] == WinScore)
		{
			// Congratulate player 3
			ResetGame();
			WinText.text = "Player 3 Wins!";
			WinText.enabled = true;
			GoStart.SetActive(true);
		}

		// if player 4 wins
		else if (Players.Length > 3 && playerScores[3] == WinScore)
		{
			// Congratulate player 4
			ResetGame();
			WinText.text = "Player 4 Wins!";
			WinText.enabled = true;
			GoStart.SetActive(true);
		}

		// if players 1 and 2 win
		else if (Players.Length > 1 && playerScores[0] == WinScore &&  playerScores[1] == WinScore)
		{
			// Congratulate players 1 and 2
			ResetGame();
			WinText.text = "Players 1 and 2 Win!";
			WinText.enabled = true;
			GoStart.SetActive(true);
		}

		// if players 1 and 3 win
		else if (Players.Length > 2 && playerScores[0] == WinScore && playerScores[2] == WinScore)
		{
			// Congratulate players 1 and 3
			ResetGame();
			WinText.text = "Players 1 and 3 Win!";
			WinText.enabled = true;
			GoStart.SetActive(true);
		}

		// if players 1 and 4 win
		else if (Players.Length > 3 && playerScores[0] == WinScore && playerScores[3] == WinScore)
		{
			// Congratulate players 1 and 4
			ResetGame();
			WinText.text = "Players 1 and 4 Win!";
			WinText.enabled = true;
			GoStart.SetActive(true);
		}

		// if players 2 and 3 win
		else if (Players.Length > 2 && playerScores[1] == WinScore && playerScores[2] == WinScore)
		{
			// Congratulate players 2 and 3
			ResetGame();
			WinText.text = "Players 2 and 3 Win!";
			WinText.enabled = true;
			GoStart.SetActive(true);
		}

		// if players 2 and 4 win
		else if (Players.Length > 3 && playerScores[1] == WinScore && playerScores[3] == WinScore)
		{
			// Congratulate players 2 and 4
			ResetGame();
			WinText.text = "Players 2 and 4 Win!";
			WinText.enabled = true;
			GoStart.SetActive(true);
		}

		// if players 3 and 4 win
		else if (Players.Length > 3 && playerScores[2] == WinScore && playerScores[3] == WinScore)
		{
			// Congratulate players 3 and 4
			ResetGame();
			WinText.text = "Players 3 and 4 Win!";
			WinText.enabled = true;
			GoStart.SetActive(true);
		}

		// if players 1, 2 and 3 win
		else if (Players.Length > 2 && playerScores[0] == WinScore && playerScores[1] == WinScore && playerScores[2] == WinScore)
		{
			// Congratulate players 1, 2 and 3
			ResetGame();
			WinText.text = "Players 1, 2 and 3 Win!";
			WinText.enabled = true;
			GoStart.SetActive(true);
		}

		// if players 1, 2 and 4 win
		else if (Players.Length > 3 && playerScores[0] == WinScore && playerScores[1] == WinScore && playerScores[3] == WinScore)
		{
			// Congratulate players 1, 2 and 4
			ResetGame();
			WinText.text = "Players 1, 2 and 4 Win!";
			WinText.enabled = true;
			GoStart.SetActive(true);
		}

		// if players 1, 3 and 4 win
		else if (Players.Length > 3 && playerScores[0] == WinScore && playerScores[2] == WinScore && playerScores[3] == WinScore)
		{
			// Congratulate players 1, 3 and 4
			ResetGame();
			WinText.text = "Players 1, 3 and 4 Win!";
			WinText.enabled = true;
			GoStart.SetActive(true);
		}

		// if players 2, 3 and 4 win
		else if (Players.Length > 3 && playerScores[1] == WinScore && playerScores[2] == WinScore && playerScores[3] == WinScore)
		{
			// Congratulate players 2, 3 and 4
			ResetGame();
			WinText.text = "Players 2, 3 and 4 Win!";
			WinText.enabled = true;
			GoStart.SetActive(true);
		}

		else if (isGamePlaying)
		{
			// Starts next round
			Ball.GetComponent<BallMovement>().ResetBall();
			StartGame();
		}
	}
}
