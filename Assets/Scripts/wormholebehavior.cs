using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wormholebehavior : MonoBehaviour {
	public GameObject otherWormhole;
	private Vector3 spawn;
	public bool used;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		spawn = otherWormhole.transform.position;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "player"){
			other.transform.position = spawn;
			used = true;
			Destroy (this);
			Destroy (otherWormhole);
		}
	}

}
