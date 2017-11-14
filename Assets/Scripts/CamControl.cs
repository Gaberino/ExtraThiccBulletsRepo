using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour {

	public static CamControl instance;

	Vector2  truepos = Vector2.zero;
	public float minIntensity;
	public float maxIntensity;

	public float shakeReturn;
	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		truepos *= shakeReturn;

		this.transform.position = truepos;
		this.transform.position += Vector3.back * 15;
	}

	public void AddShake(){
		truepos += Random.insideUnitCircle * Random.Range(minIntensity, maxIntensity);
		Debug.Log ("Shook");
	}
}
