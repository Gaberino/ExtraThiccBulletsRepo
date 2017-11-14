using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingRing : MonoBehaviour {

    public float speed;
    public bool grav;
    public float gravRadius;
    public float force;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
        if (!grav) { return; }
        Collider2D[] colls = Physics2D.OverlapCircleAll(transform.position, gravRadius);
        if(colls.Length > 0)
        {
            foreach(Collider2D coll in colls) {
                float dist = Vector2.Distance(transform.position, coll.transform.position);
                if(coll.tag.Contains("Asteroid")) {
                    Vector2 dir = (Vector2)(transform.position - coll.transform.position).normalized;
                    coll.GetComponent<Rigidbody2D>().AddForce(dir* force);
                }
            }
        }
	}
}
