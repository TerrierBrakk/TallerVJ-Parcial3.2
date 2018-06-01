using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovErtical : MonoBehaviour {

	public GameObject platform;
	public Transform pos_inicial;
	public Transform pos_final;
	private Transform pos_sig;
	public float vel;

	// Use this for initialization
	void Start () {
		pos_sig = pos_final;	
	}
	
	// Update is called once per frame
	void Update () {

		platform.transform.position = Vector2.MoveTowards (platform.transform.position, pos_sig.position, Time.deltaTime * vel);

		if(platform.transform.position ==pos_sig.position)
		{
			pos_sig = pos_sig == pos_final ? pos_inicial : pos_final;
		} 
	}  
}
