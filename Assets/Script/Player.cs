using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Controller2d))]
	
public class Player : MonoBehaviour {
	Controller2d controller;

	void Start()
	{
		controller = GetComponent<Controller2d>();
	}

}
