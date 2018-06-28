using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCamera : MonoBehaviour {


    void Update()
    {
        transform.position = new Vector3(GameObject.FindWithTag("Jugador").transform.position.x, GameObject.FindWithTag("Jugador").transform.position.y, transform.position.z);
    }
}