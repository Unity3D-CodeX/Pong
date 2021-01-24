using System.Collections;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
	/// Public variables
	
	// Ball speed
	public float MovementSpeed;

	// Spawnpoint
	public GameObject BallSpawn;

	// Debug direction
	public BallDirection DebugDirection;

	/// Private variables

	// Velocity and direction
	private Vector2 velocity;
	private BallDirection direction;

	// Direction velocities
	private Vector2 upperRightVel;
	private Vector2 upperLeftVel;
	private Vector2 lowerLeftVel;
	private Vector2 lowerRightVel;

	private Rigidbody2D myRigidBody2D;

	// Resets the ball
	public void ResetBall()
    {
        // initialize variables
        myRigidBody2D = GetComponent<Rigidbody2D>();

        // initialize directional velocities
        upperRightVel = new Vector2(1, 0.5f);
        upperLeftVel = new Vector2(-1, 0.5f);
        lowerLeftVel = new Vector2(-1, -0.5f);
        lowerRightVel = new Vector2(1, -0.5f);

        // reset position and velocity of ball
        transform.position = BallSpawn.transform.position;
        myRigidBody2D.velocity = Vector2.zero;

        if (DebugDirection != BallDirection.NoDebugDirection)
        {
            direction = DebugDirection;
        }
        else
        {
            direction = randomizeBallDirection();
        }
        SetVelocityDirection();
        velocity *= MovementSpeed;
    }

    private void SetVelocityDirection()
    {
        switch (direction)
        {
            case BallDirection.UpperLeft:
                velocity = upperLeftVel;
                break;
            case BallDirection.UpperRight:
                velocity = upperRightVel;
                break;
            case BallDirection.LowerLeft:
                velocity = lowerLeftVel;
                break;
            case BallDirection.LowerRight:
                velocity = lowerRightVel;
                break;
            default:
                velocity = upperLeftVel;
                break;
        }
    }

    private BallDirection randomizeBallDirection()
    {
        int randNum = Random.Range(0, 3);
        BallDirection returnDir;
        switch (randNum)
        {
            case 0:
                returnDir = BallDirection.UpperLeft;
                break;
            case 1:
                returnDir = BallDirection.UpperRight;
                break;
            case 2:
                returnDir = BallDirection.LowerLeft;
                break;
            case 3:
                returnDir = BallDirection.LowerRight;
                break;
            default:
                returnDir = BallDirection.UpperLeft;
                break;
        }
        return returnDir;
    }

	// Gets the ball moving
	public void StartBallMovement()
	{
		myRigidBody2D.velocity = Vector2.zero;
		StartCoroutine(Pause());
		myRigidBody2D.velocity = velocity;
	}

	private IEnumerator Pause()
	{
		Time.timeScale = 0.00000000000001f;
		float pauseEndTime = Time.realtimeSinceStartup + 1;
		while (Time.realtimeSinceStartup < pauseEndTime)
		{
			yield return 0;
		}
		Time.timeScale = 1;
	}
}
