using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

	public static bool GameIsPaused=false;

	public GameObject pauseMenUI;

	void Update(){
		if (Input.GetKeyDown (KeyCode.P)) 
		{
			if (GameIsPaused) 
			{
				Resume ();
			} else {
				Paus ();
			}
		}
	}
		public void Resume()
		{
		pauseMenUI.SetActive (false);
		Time.timeScale = 1f;
		GameIsPaused = false;
			
		}

		void Paus()
		{
		pauseMenUI.SetActive (true);
		Time.timeScale = 0f;
		GameIsPaused = true;
		}

	public void LoadMenu()
	{
		Debug.Log ("Loading Menu..");
	}

	public void QuitGame()
	{
		Debug.Log ("Quitting game..."); 
	}
}
