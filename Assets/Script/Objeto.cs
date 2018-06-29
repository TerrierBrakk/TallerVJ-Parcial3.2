using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objeto : MonoBehaviour {

	void OnCollisionEnter(Collision other)
	{

		if (other.gameObject.CompareTag ("Player")) {
			gameObject.SetActive (false);

		}
	}
}
