using UnityEngine;

public class GoalController : MonoBehaviour
{
	public Player PlayerGoal;

	private GameController gameController;

	public void Start()
	{
		gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Ball"))
		{
			// if player 1 was scored on, give all other players a point
			if (PlayerGoal == Player.Player1)
			{
				gameController.AddScore(Player.Player2);
				gameController.AddScore(Player.Player3);
				gameController.AddScore(Player.Player4);
			}

			// if player 2 was scored on, give all other players a point
			else if (PlayerGoal == Player.Player2)
			{
				gameController.AddScore(Player.Player1);
				gameController.AddScore(Player.Player3);
				gameController.AddScore(Player.Player4);
			}

			// if player 3 was scored on, give all other players a point
			else if (PlayerGoal == Player.Player3)
			{
				gameController.AddScore(Player.Player1);
				gameController.AddScore(Player.Player2);
				gameController.AddScore(Player.Player4);
			}

			// if player 4 was scored on, give all other players a point
			else if (PlayerGoal == Player.Player4)
			{
				gameController.AddScore(Player.Player1);
				gameController.AddScore(Player.Player2);
				gameController.AddScore(Player.Player3);
			}
		}
	}
}
