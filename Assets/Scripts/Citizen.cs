using UnityEngine;

public class Citizen
{
	string CitizenName; // Store Name
	int CitizenAge; // Store Age

	public Citizen(string name, int age, Transform citizenManager)
	{
		CitizenName = name;
		CitizenAge = age;

		GameObject CitizenBody = GameObject.CreatePrimitive(PrimitiveType.Cube);; // Create a GameObject

		CitizenBody.transform.localScale = new Vector3 (1f, 2f, 1f); // Resize Object
		CitizenBody.GetComponent<Renderer> ().material.SetColor ("_Color", Color.yellow); // Set Object Color
		CitizenBody.name = name + age; // Set Object Name

		CitizenBody.transform.SetParent (citizenManager); // Manager
		CitizenBody.transform.position = new Vector3 (Random.Range(10,40), .3f, Random.Range(10,40)); // Random Position
			
		Debug.Log (CitizenName + " " + CitizenAge + "yo"); // Print Citizen Name And Age 
	}
}
