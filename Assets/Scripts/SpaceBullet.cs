using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceBullet : MonoBehaviour {

	//spacebullets have kinematic 2d rigidbodies

	public GameObject hitParticlePrefab;
	public Vector2 velocity;
	public float life;
	public bool pierceTerrain = false;
	public int ownerID = 0;
	public float elapsedLife = 0;
	Rigidbody2D myRB;

	void Start(){
		myRB = this.GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {
		elapsedLife += Time.deltaTime;

		if (elapsedLife > life) {
			GameObject newParticle = Instantiate (hitParticlePrefab, this.transform.position, Quaternion.identity);
			Destroy (newParticle, 1f);
			Destroy (this.gameObject);
		}
		myRB.position += velocity * Time.deltaTime;
	}

	void OnTriggerEnter2D(Collider2D other){
		if(!other.gameObject.name.Contains("Boolet")){
			if (other.GetComponent<PlayerMovement> () != null) {
				if (other.GetComponent<PlayerMovement> ().playerNumber != ownerID) {
					other.GetComponent<PlayerMovement> ().TakeDamage(ownerID);
					GameObject newParticle = Instantiate (hitParticlePrefab, this.transform.position, Quaternion.identity);
					Destroy (newParticle, 1f);
					Destroy (this.gameObject);
				}
			}else if(other.tag == "WinZone")
            {
                // poop
            }
            else if (!pierceTerrain) {
				GameObject newParticle = Instantiate (hitParticlePrefab, this.transform.position, Quaternion.identity);
				Destroy (newParticle, 1f);
				Destroy (this.gameObject);
			}
		}
	}
}
