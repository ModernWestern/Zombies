using UnityEngine;

public class Zombie
{
	Color zombieColor; // Set Color

	public Zombie (Color color, Transform zombieManager)
	{
		zombieColor = color; // Store Color
		GameObject zombieBody = GameObject.CreatePrimitive (PrimitiveType.Capsule); // Create a GameObject
 
		zombieBody.GetComponent<Renderer> ().material.SetColor ("_Color", zombieColor); // Set Object Color
		zombieBody.name = GetColorName (zombieBody); // Set Object Name

		zombieBody.transform.SetParent (zombieManager); // Manager
		zombieBody.transform.position = new Vector3 (Random.Range(10,40), .3f, Random.Range(10,40)); // Random Position

		Debug.Log ("I'm a " + GetColorName(zombieBody)); // Print Sort of Zombie
	}

	string colorName; // Store Color Name

	string GetColorName(GameObject go) // Hard Method
	{
		Color goColor; // Store Color From Object
		goColor = go.GetComponent<Renderer>().material.color; // Get Color

		if (goColor == Color.cyan) 
		{
			colorName = "Zombie Cyan";
		}
		if (goColor == Color.magenta) 
		{
			colorName = "Zombie Magenta";
		}
		if (goColor == Color.green) 
		{
			colorName = "Zombie Green";
		}
		return colorName;
	}
}
