using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBax : MonoBehaviour {

    public ShotModifier weaponHeld;
    public float lifeTime;
    float startTime;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time - startTime >= lifeTime)
        {
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        PlayerMovement player = coll.GetComponent<PlayerMovement>();
        if(player != null)
        {
            player.pickUpWeapon(weaponHeld);
            Destroy(gameObject);
        }
    }
}
