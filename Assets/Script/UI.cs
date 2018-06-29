using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour {
	private int vidas=3;
	public Text UIvidas;
	int daño=1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		UIvidas.text = vidas.ToString ();
		perdivida ();

	}


	void OnCollisionEnter(Collision other)
	{
		print ("Has Perdido una vida");
		if (other.gameObject.CompareTag ("Finish")) 
		{
			vidas -= daño;
			print ("menos una vida");
		}
	}

	void perdivida()
	{
		if (vidas <= 0) 
		{
			death ();
		}
	}
	void death()
	{		
			SceneManager.LoadScene ("GameOver");
	}
}
