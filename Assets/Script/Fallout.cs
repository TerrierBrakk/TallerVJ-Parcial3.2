using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fallout : MonoBehaviour {
	[SerializeField]private Transform Player;
	[SerializeField]private Transform respawnPoint;


	void OnCollisionEnter(Collision collision)
	{
		Player.transform.position = respawnPoint.transform.position;
		print ("colisione");


	}

}