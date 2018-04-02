using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour 
{
	public string namesFile; // Public Field To Type File Name
	Transform citizenManager, zombieManager; // Managers

	GameObject Scene() // Plane Generator
	{
		GameObject planeScene = GameObject.CreatePrimitive (PrimitiveType.Plane); // Create a GameObject
		planeScene.name = "Surface";
		planeScene.transform.position = new Vector3 (0f, -.7f, 	-3.5f);
		planeScene.transform.localScale = new Vector3 (10f, 10f, 10f);
		planeScene.GetComponent<Renderer> ().material.SetColor ("_Color", Color.black);
		return planeScene;
	}

	string CharacterNames() // Name Generator
	{
		string [] characterNames; // Store Names
		var txt = Resources.Load (namesFile, typeof(TextAsset)) as TextAsset; // Names File
		characterNames = txt.text.Split ('\n'); // Load Names And Split By Spaces
		int selectedName = Random.Range (0, characterNames.Length); // Select a Name From Names File
		return characterNames[selectedName]; // Return a Name
	}

	int CharacterAge() // Age Generator
	{
		int age;
		age = Random.Range (15, 101); // Random Age
		return age;
	}
		
	Color ZombieColor() // Color Generator
	{
		Color zombie;
		int setColor = Random.Range (0, 3); // Random Color
		switch (setColor)
		{
		case 0:
			zombie = Color.cyan;
			break;
		case 1:
			zombie = Color.magenta;
			break;
		case 2:
			zombie = Color.green;
			break;
		default:
			zombie = Color.red;
			break;
		}
		return zombie;
	}

	void Awake()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

		new Hero (CharacterNames ()); // Hero

		// MANAGERS
		zombieManager = new GameObject().transform;
		zombieManager.name = "Threats";

		citizenManager = new GameObject ().transform;
		citizenManager.name = "Population";
		// END MANAGERS

		// CITIZEN & ZOMBIES
		for (int i = 0; i < Random.Range (4, 10); i++) // Population Number (4,9)
		{
			int coz = Random.Range (0, 2); // Citizen Or Zombie

			switch (coz) 
			{
			case 0:
				new Zombie (ZombieColor (), zombieManager);
				break;
			case 1:
				new Citizen (CharacterNames (), CharacterAge (), citizenManager);
				break;
			default:
				print ("Popultion Zero");
				break;
			}
		}
		// END CITIZEN & ZOMBIES

		Scene(); // Plane
	}
}
