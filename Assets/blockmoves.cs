using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class blockmoves : MonoBehaviour {

	public float speed;
	public float distanceToMove;


	
	// Update is called once per frame
	void Update () {
		//transform.Rotate(Vector3.forward * speed * Time.deltaTime);
		float sinwave = Mathf.Cos (Time.frameCount / (distanceToMove * 100)) * distanceToMove;
		Debug.Log (sinwave);
		transform.Translate (Vector3.up * speed * sinwave);
	}
}
