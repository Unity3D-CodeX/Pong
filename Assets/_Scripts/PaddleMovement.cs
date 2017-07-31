using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
	/// Public variables
	public float MovementSpeed;
	public bool isPlayer1;
	public PlayerPart PaddlePart;

	/// Private variables
	private Rigidbody2D myRigidBody2D;
	private GameController gameController;
	private Vector2 movement;
	private bool isGameStarted;

	public void Start ()
	{
		/// Getting private variables
		myRigidBody2D = GetComponent<Rigidbody2D>();
		gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

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

	public void OnCollisionEnter2D(Collision2D collision)
	{
		ContactPoint2D contact = collision.contacts[0];
		float contactPosY = contact.point.y;
		if (collision.gameObject == gameController.Ball)
		{
			if (contactPosY < transform.position.y - 1)
			{
				PaddlePart = PlayerPart.Lower;
			}
			else if (contactPosY > transform.position.y + 1)
			{
				PaddlePart = PlayerPart.Upper;
			}
			else
			{
				PaddlePart = PlayerPart.Middle;
			}
		}
	}
}
