using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceBullet : MonoBehaviour {

	//spacebullets have kinematic 2d rigidbodies

	public Vector2 velocity;
	public float life;
	public int ownerID = 0;
	private float elapsedLife = 0;

	// Update is called once per frame
	void Update () {
		elapsedLife += Time.deltaTime;

		if (elapsedLife > life) Destroy (this.gameObject);
		this.transform.Translate(velocity.x * Time.deltaTime, velocity.y * Time.deltaTime, 0);
	}

	void OnTriggerEnter2D(Collider2D other){
		//if the other object is a player and has aa different ownerID call the kill method
		Destroy(this.gameObject);
	}
}
