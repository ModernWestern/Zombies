using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_move : MonoBehaviour 
{
	float walk = .25f; // Walk value
	float sprint = .5f; // Sprint value
	float lerpSpeed; // Store speed change
	private Rigidbody rb; // Store rigidvody

	void Axis(Rigidbody rb_, float speed_) // Axes method using rigidbody
	{
		// FORWARD
		if (Input.GetKey (KeyCode.W)) 
		{
			rb_.MovePosition (transform.position + transform.forward * speed_);
		}
		// LEFT
		if (Input.GetKey (KeyCode.A)) 
		{
			rb_.MovePosition (transform.position - transform.right * speed_);
		}
		// BACK
		if (Input.GetKey (KeyCode.S)) 
		{
			rb_.MovePosition (transform.position - transform.forward * speed_);
		}
		// RIGHT
		if (Input.GetKey (KeyCode.D)) 
		{
			rb_.MovePosition (transform.position + transform.right * speed_);
		}
		// FORWARD + RIGHT
		if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.D)) 
		{
			rb_.MovePosition (transform.position + (transform.forward + transform.right) * speed_);
		}
		// FORWARD + LEFT
		if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.A)) 
		{
			rb_.MovePosition (transform.position + (transform.forward - transform.right) * speed_);
		}
		// BACK + RIGHT
		if (Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.D)) 
		{
			rb_.MovePosition (transform.position - (transform.forward - transform.right) * speed_);
		}
		// BACK + LEFT
		if (Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.A)) 
		{
			rb_.MovePosition (transform.position - (transform.forward + transform.right) * speed_);
		}
	}
		
	void Move_() // Lerping method
	{
		if (Input.GetKey (KeyCode.LeftShift)) // Shift sprint
		{
			lerpSpeed = Mathf.Lerp (lerpSpeed, sprint, (6 * Time.fixedDeltaTime));
		} 
		else // Just walk
		{
			lerpSpeed = Mathf.Lerp (lerpSpeed, walk, (9 * Time.fixedDeltaTime));
		}

		Axis (rb, lerpSpeed); // Allocate rigidbody and speed changes
	}

	void Awake()
	{
		rb = GetComponent<Rigidbody> (); // Get rigidbody
		lerpSpeed = walk; // First speed change is same to walk
	}

	void FixedUpdate()
	{
		Move_ ();
	}
}
