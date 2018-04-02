using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero
{
	string heroName; // Store Name

	public Hero(string name)
	{
		GameObject HeroBody; // Create a GameObject to Store an Object
		HeroBody = HeroGo (); // "Create" Object
		HeroBody.name = "Hero"; // Set Object Name

		GameObject cam = GameObject.FindGameObjectWithTag ("MainCamera"); // Find Main Camera
		cam.name = name.ToUpper(); // Set Camera Name (A Citizen Name)
		cam.transform.SetParent (HeroBody.transform); // Manager
		HeroBody.transform.position = new Vector3 (Random.Range(10,40), .3f, Random.Range(10,40)); // Random Position
	}

	GameObject HeroGo() // Hero Generator
	{
		GameObject body; // Create a GameObject to Store an Object
		body = new GameObject(); // Create Parent

		// RIGIDBODY
		body.AddComponent<Rigidbody> ();
		Rigidbody rb = body.GetComponent<Rigidbody> ();
		rb.mass = 60f;
		rb.drag = 6f;
		rb.angularDrag = .05f;
		rb.interpolation = RigidbodyInterpolation.Interpolate;
		rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
		rb.constraints = RigidbodyConstraints.FreezeRotation;
		// END RIGIDBODY

		// COLLIDER
		body.AddComponent<CapsuleCollider>();
		CapsuleCollider cc = body.GetComponent<CapsuleCollider> ();
		cc.radius = .5f;
		cc.height = 2f;
		cc.direction = 1; // 0 = x, 1 = y, 2 = z
		// END COLLIDER 

		// SCRIPTS
		body.AddComponent<CustomGravity> ();
		CustomGravity cg = body.GetComponent<CustomGravity> ();
		cg.gravityScale = 15;
		body.AddComponent<FPS_cam> ();
		body.AddComponent<FPS_move> ();
		body.AddComponent<HideCursorOnScreen> ();
		// END SCRIPTS

		// GUN
		GameObject gun = GameObject.CreatePrimitive(PrimitiveType.Cube); // Create a Gun
		gun.name = "Gun";
		gun.transform.position = new Vector3 (.38f, -.4f, .4f);
		gun.transform.localScale = new Vector3 (.28f, .26f, 1f);
		gun.transform.SetParent (body.transform); // Rig
		gun.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
		// END GUN
		return body;
	}
}
