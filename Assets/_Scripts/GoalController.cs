using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
	public bool isPlayer1Goal;

	private GameController gameController;

	public void Start()
	{
		gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Ball"))
		{
			if (isPlayer1Goal)
			{
				gameController.AddScore(Player.Player2);
			}
			else
			{
				gameController.AddScore(Player.Player1);
			}
		}
	}
}
