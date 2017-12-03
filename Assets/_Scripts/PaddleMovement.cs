using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
	/// Public variables
	public float MovementSpeed;
	public Player WhichPlayer;

	/// Private variables
	private Rigidbody2D myRigidBody2D;
	private Vector2 movement;
	private bool isGameStarted;

	public void Start ()
	{
		/// Getting private variables
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
		if (WhichPlayer == Player.Player1)
		{
			transform.position = new Vector2(-9, 0);
		}
		else if (WhichPlayer == Player.Player2)
		{
			transform.position = new Vector2(9, 0);
		}
		else if (WhichPlayer == Player.Player3)
		{
			transform.position = new Vector2(0, 4.8f);
		}
		else
		{
			transform.position = new Vector2(0, -4.8f);
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
		if (WhichPlayer == Player.Player1)
		{
			Player1Move();
		}
		else if (WhichPlayer == Player.Player2)
		{
			Player2Move();
		}
		else if (WhichPlayer == Player.Player3)
		{
			Player3Move();
		}
		else
		{
			Player4Move();
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

	// Movement control for player 3
	private void Player3Move()
	{
		movement = new Vector2(MovementSpeed * Input.GetAxisRaw("Player 3 Movement"), 0);
		myRigidBody2D.velocity = movement;
	}

	// Movement control for player 4
	private void Player4Move()
	{
		movement = new Vector2(MovementSpeed * Input.GetAxisRaw("Player 4 Movement"), 0);
		myRigidBody2D.velocity = movement;
	}
}
