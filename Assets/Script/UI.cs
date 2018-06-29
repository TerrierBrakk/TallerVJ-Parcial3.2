using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour {
	int contador=0;
	private int vidas=3;
	public Text UIvidas;
	public Text UIScore;
	int daño=1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		UIvidas.text = vidas.ToString ();
		UIScore.text = contador.ToString ();
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
		if (other.gameObject.CompareTag ("Objeto")) {
			contador=contador+1;
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
