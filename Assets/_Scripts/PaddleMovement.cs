using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
	/// Public variables
	public float MovementSpeed;
	public bool isPlayer1;

	/// Private variables
	private Transform myTransform;
	private Rigidbody2D myRigidBody2D;
	private Vector2 movement;
	private bool isGameStarted;

	public void Start ()
	{
		/// Getting private variables
		myTransform = GetComponent<Transform>();
		myRigidBody2D = GetComponent<Rigidbody2D>();

		//ResetPlayer();
	}

	// Reset the player paddles
	public void ResetPlayer()
	{
		isGameStarted = false;

		// Reset Movement
		movement = new Vector2(0, 0);

		// Reset the position
		if (isPlayer1)
		{
			transform.position = new Vector2(-9, 0);
		}
		else
		{
			transform.position = new Vector2(9, 0);
		}
	}

	public void StartGame()
	{
		isGameStarted = true;
	}

	public void FixedUpdate ()
	{
		if (isGameStarted)
		{
			DifferentiatePlayerInput();
		}
	}

	// Call the correct player movement function
	private void DifferentiatePlayerInput()
	{
		if (isPlayer1)
		{
			Player1Move();
		}
		else
		{
			Player2Move();
		}
	}

	// Movement control for player 1
	private void Player1Move()
	{
			movement = new Vector2(0, MovementSpeed * Input.GetAxisRaw("Player 1 Movement"));
			myRigidBody2D.velocity = movement;
	}

	// Movement control for player 2
	private void Player2Move()
	{
			movement = new Vector2(0, MovementSpeed * Input.GetAxisRaw("Player 2 Movement"));
			myRigidBody2D.velocity = movement;
	}
}
