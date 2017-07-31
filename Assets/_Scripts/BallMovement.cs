using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
	public float MovementSpeed;
	
	private Vector2 velocity;
	private Rigidbody2D myRigidBody2D;
	private GameController gameController;
	private bool isGameStarted;

	// Resets the ball
	public void ResetBall()
	{
		gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
		myRigidBody2D = GetComponent<Rigidbody2D>();

		isGameStarted = false;
		transform.position = Vector2.zero;
	}

	// Gets the ball moving
	public void StartBallMovement()
	{
		velocity = new Vector2(-MovementSpeed, MovementSpeed);
		isGameStarted = true;
	}

	public void FixedUpdate()
	{
		if (isGameStarted)
		{
			myRigidBody2D.velocity = velocity;
		}
	}

	public void OnCollisionEnter2D(Collision2D collision)
	{
		// if the ball collided with player 1
		if (collision.gameObject == gameController.Players[0])
		{
			velocity.x = MovementSpeed;
			if (gameController.Players[0].GetComponent<PaddleMovement>().PaddlePart == PlayerPart.Upper)
			{
				velocity.y = MovementSpeed;
			}
			else if (gameController.Players[0].GetComponent<PaddleMovement>().PaddlePart == PlayerPart.Lower)
			{
				velocity.y = -MovementSpeed;
			}
		}

		// if the ball collided with player 2
		else if (collision.gameObject == gameController.Players[1])
		{
			// reverse horizontal direction
			velocity.x = -MovementSpeed;

			if (gameController.Players[1].GetComponent<PaddleMovement>().PaddlePart == PlayerPart.Upper)
			{
				// move up if hit upper half
				velocity.y = MovementSpeed;
			}
			else if (gameController.Players[1].GetComponent<PaddleMovement>().PaddlePart == PlayerPart.Lower)
			{
				// move down if hit lower half
				velocity.y = -MovementSpeed;
			}
		}

		// if the ball collided with the top border
		else if (collision.gameObject == gameController.Borders[0])
		{
			velocity.y = -MovementSpeed;
		}

		// if the ball collided with the bottom border
		else if (collision.gameObject == gameController.Borders[1])
		{
			velocity.y = MovementSpeed;
		}
		myRigidBody2D.velocity = velocity;
	}
}
