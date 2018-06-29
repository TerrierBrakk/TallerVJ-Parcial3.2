using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag=="platform")
		{
			transform.parent=other.transform;
		}
	}

	void OnCollisionExit(Collision other)
	{
		if (other.gameObject.tag == "platform") 
		{
		
			transform.parent = null;
		}
	}
}
