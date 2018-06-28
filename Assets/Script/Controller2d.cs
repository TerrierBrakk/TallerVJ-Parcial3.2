using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent (typeof(BoxCollider2D))]
public class Controller2d : MonoBehaviour {

	const float swidth =0.015f;
	public int horizontalray = 4;
	public int verticalray = 4;
	BoxCollider2D collider;
	RayCastOrigen raycastorigen;
	float horizontalrayspacing;
	float verticalrayspacing;

	void Start(){
	
		collider = GetComponent<BoxCollider2D>();
	}

	void Update()
	{
		UpdateRaycastOrigen ();
		rayspacing ();

		for (int i = 0; i < verticalray; i++) 
		{
			Debug.DrawRay(raycastorigen.bottomLeft=Vector2.right * verticalrayspacing * i, Vector2.up * -2,Color.red);
		}
	}

	void UpdateRaycastOrigen(){
		Bounds bounds = collider.bounds;
		bounds.Expand (swidth * -2);

		raycastorigen.bottomLeft = new Vector2 (bounds.min.x, bounds.min.y);
		raycastorigen.bottomRight= new Vector2 (bounds.max.x, bounds.min.y);
		raycastorigen.topLeft = new Vector2 (bounds.min.x, bounds.max.y);
		raycastorigen.topRight = new Vector2 (bounds.max.x, bounds.max.y);
	}

	void rayspacing(){
		Bounds bounds = collider.bounds;
		bounds.Expand (swidth * -2);
		horizontalray = Mathf.Clamp (horizontalray, 2, int.MaxValue);
		verticalray = Mathf.Clamp (verticalray, 2, int.MaxValue);

		horizontalrayspacing = bounds.size.y / (horizontalray - 1);
		verticalrayspacing = bounds.size.x / (verticalray - 1);
	}

	struct RayCastOrigen {
		public Vector2 topLeft, topRight;
		public Vector2 bottomLeft,bottomRight;
	}

}
