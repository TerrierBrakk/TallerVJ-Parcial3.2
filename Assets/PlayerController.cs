using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float velocidad = 10;
	public float VelocidadSalto=10;
	public float saltobajo=2f;
	public float saltocaida=2.5f; 

	Transform mytrasn;
	Rigidbody2D rb;

	bool isGround=false;
	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody2D>();
		mytrasn = this.transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Move (Input.GetAxis ("Horizontal"));
		Jump ();
	}

	public void Move(float controlHorizontal)
	{

	}

	public void Jump()
	{
		if (rb.velocity.y < 0) {
			rb.velocity += Vector2.up * Physics2D.gravity.y * (saltocaida - 1) * Time.deltaTime;
		} else if (rb.velocity.y > 0 && !Input.GetButton("Jump")){
			rb.velocity += Vector2.up * Physics2D.gravity.y * (saltobajo - 1) * Time.deltaTime;		}
		}
  }

