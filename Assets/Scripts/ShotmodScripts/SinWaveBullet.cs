using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinWaveBullet : MonoBehaviour {

	public float sinVal;
	private Vector3 origScale;

	//spacebullets have kinematic 2d rigidbodies

	public GameObject hitParticlePrefab;
	public Vector2 velocity;
	public float life;
	public bool pierceTerrain = true;
	public int ownerID = 0;
	public float elapsedLife = 0;

	public float scale;

	Rigidbody2D myRB;



	// Use this for initialization
	void Start () {
		myRB = this.GetComponent<Rigidbody2D>();
		origScale = new Vector3(1, 1, 1);
		this.transform.localScale = origScale;
	}
	
	// Update is called once per frame
	void Update () {
		elapsedLife += Time.deltaTime;

		if (elapsedLife > life) {
			GameObject newParticle = Instantiate (hitParticlePrefab, this.transform.position, Quaternion.identity);
			Destroy (newParticle, 1f);
			Destroy (this.gameObject);
		}

		myRB.velocity = velocity;

		float sinwave = Mathf.Sin (elapsedLife * 10) + 1;
		Debug.Log (sinwave);
		this.transform.localScale = origScale * sinwave * scale;
	}

	void OnTriggerEnter2D(Collider2D other){
		if(!other.gameObject.name.Contains("Boolet")){
			if (other.GetComponent<PlayerMovement> () != null) {
				if (other.GetComponent<PlayerMovement> ().playerNumber != ownerID) {
					other.GetComponent<PlayerMovement> ().TakeDamage (ownerID);
					GameObject newParticle = Instantiate (hitParticlePrefab, this.transform.position, Quaternion.identity);
					Destroy (newParticle, 1f);
					Destroy (this.gameObject);
				}
			}
			else if (other.tag == "WinZone") {
			}
			else if (!pierceTerrain) {
				GameObject newParticle = Instantiate (hitParticlePrefab, this.transform.position, Quaternion.identity);
				Destroy (newParticle, 1f);
				Destroy (this.gameObject);
			}
		}
	}
}
