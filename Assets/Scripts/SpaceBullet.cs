using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceBullet : MonoBehaviour {

	//spacebullets have kinematic 2d rigidbodies

	public Vector2 velocity;
	public float life;
	public int ownerID = 0;
	private float elapsedLife = 0;
	Rigidbody2D myRB;

	void Start(){
		myRB = this.GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {
		elapsedLife += Time.deltaTime;

		if (elapsedLife > life) Destroy (this.gameObject);
		myRB.position += velocity * Time.deltaTime;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.GetComponent<PlayerMovement>() != null){
			if (other.GetComponent<PlayerMovement>().playerNumber != ownerID) {
				other.GetComponent<PlayerMovement>().Die(ownerID);
				Destroy(this.gameObject);
			}
		}
	}
}
