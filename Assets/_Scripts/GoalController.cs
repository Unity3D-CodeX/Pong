using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
	public bool isPlayer1Goal;

	private GameObject gameController;

	public void Start()
	{
		gameController = GameObject.FindGameObjectWithTag("GameController");
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Ball"))
		{
			if (isPlayer1Goal)
			{
				gameController.GetComponent<GameController>().AddScore(Player.Player2);
			}
			else
			{
				gameController.GetComponent<GameController>().AddScore(Player.Player1);
			}
		}
	}
}
