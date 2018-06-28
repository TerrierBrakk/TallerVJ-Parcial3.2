using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataforma : MonoBehaviour {
    public BoxCollider colisionador;
    public GameObject Jugador;

	// Use this for initialization
	void Start () {
        colisionador.isTrigger = true;
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Jugador.transform.position.y > (transform.position.y + .5f ))
        {
            colisionador.isTrigger = false;
        }
        else
        {
            colisionador.isTrigger = true;
        }
        
    }
}
