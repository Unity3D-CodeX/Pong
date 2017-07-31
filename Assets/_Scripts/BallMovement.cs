using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
	public float MovementSpeed;

	private Transform myTransform;
	private Rigidbody2D myRigidbody2D;

	private bool isGameStarted;

	// Resets the ball
	public void ResetBall()
	{
		myTransform = GetComponent<Transform>();
		myRigidbody2D = GetComponent<Rigidbody2D>();

		isGameStarted = false;
		transform.position = Vector2.zero;
	}

	// Gets the ball moving
	public void StartBallMovement()
	{
		myRigidbody2D.velocity = new Vector2(-MovementSpeed, MovementSpeed);
		isGameStarted = true;
	}

	public void FixedUpdate()
	{
		if (isGameStarted)
		{
			myRigidbody2D.velocity = MovementSpeed * myRigidbody2D.velocity.normalized;
		}
	}

	public void OnCollisionEnter2D(Collision2D collision)
	{
		// if the ball collided with a player
		if (collision.otherCollider.gameObject.CompareTag("Player"))
		{
			
		}
		else if (collision.otherCollider.gameObject.CompareTag("Border"))
		{

		}
	}
}
