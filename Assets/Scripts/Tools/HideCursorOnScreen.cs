using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideCursorOnScreen : MonoBehaviour 
{
	//bool itsLocked;

	void Start () 
	{
		SetCursorLock (true);
	}

	void Update () 
	{
		// IF I WANT UNHIDE CURSOR PRESSING KEY ESC
		//		if (Input.GetKey (KeyCode.Escape)) 
		//		{
		//			SetCursorLock (!isLocked);
		//		}
	}

	void SetCursorLock (bool isLocked)
	{
		//this.itsLocked = isLocked;

		Cursor.visible = isLocked;
		//Screen.lockCursor = isLocked; // Deprecated
		Cursor.visible = !isLocked;
	}
}
