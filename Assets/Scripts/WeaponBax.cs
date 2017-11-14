using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBax : MonoBehaviour {

    public ShotModifier weaponHeld;
    public float lifeTime;
    float startTime;

    Rigidbody2D rbody;
	// Use this for initialization
	void Start () {
        startTime = Time.time;
        rbody = GetComponent<Rigidbody2D>();
        // rbody.AddForce(new Vector2(Random.Range(-2.5f, 2.5f), Random.Range(-2.5f, 2.5f)), ForceMode2D.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
        /*
		if(Time.time - startTime >= lifeTime)
        {
            Destroy(gameObject);
        }
        */
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        PlayerMovement player = coll.GetComponent<PlayerMovement>();
        if(player != null)
        {
            player.pickUpWeapon(weaponHeld);
            ParticleOverlord.instance.SpawnParticle(this.transform.position, "PickUpParticle", player.GetComponent<SpriteRenderer>().color);
            Destroy(gameObject);
        }
    }
}
