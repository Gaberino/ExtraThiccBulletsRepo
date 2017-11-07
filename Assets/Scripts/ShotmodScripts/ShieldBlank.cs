using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBlank : MonoBehaviour {

	Rigidbody2D myRB;
	private Vector3 origScale;
	public Vector2 velocity;

	public float elapsedLife = 0;
	public float life;
	public int ownerID = 0;
	public bool pierceTerrain = false;

	public float scale;

	public GameObject hitParticlePrefab;

	// Use this for initialization
	void Start () {
		myRB = this.GetComponent<Rigidbody2D> ();
		origScale = new Vector3 (1, 1, 1);
		this.transform.localScale = origScale;

	}
	
	// Update is called once per frame
	void Update () {
		elapsedLife += Time.deltaTime;
		if (elapsedLife > life) {
			
			Destroy (this.gameObject);
		}

		float sinwave = Mathf.Sin (elapsedLife * 10) + 1;
		this.transform.localScale = origScale * sinwave * scale;
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag.Contains ("Boolet")){
			if(other.GetComponent<SpaceBullet> ().ownerID != ownerID){

				GameObject newParticle = Instantiate (hitParticlePrefab, other.transform.position, Quaternion.identity);
				Destroy (newParticle, 1f);
				Destroy (other.gameObject);

			}
		}
	}


}
