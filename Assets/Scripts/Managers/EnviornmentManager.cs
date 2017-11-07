using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviornmentManager : MonoBehaviour {

	public GameObject wormhole2;
	public GameObject wormhole;
	public bool isUsed;
	private Vector3 random_point1;
	private Vector3 random_point2;
	private int lowX;
	private int highX;
	private int lowY;
	private int highY;

	// Use this for initialization
	void Start () {
		
		createWormhole ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isUsed){
			createWormhole ();
			isUsed = false;
		}
	}

	void createWormhole(){

		lowX = Random.Range (-10,0);
		lowY = Random.Range (-7, 0);
		highX = Random.Range (1, 10);
		highY = Random.Range (1, 7);


		int tempX = Random.Range (lowX, highX);
		int tempY = Random.Range (lowY, highY);

		random_point1 = new Vector3 (tempX, tempY);

		int tempX2 = Random.Range (-1 * (tempX), highX + 1);
		int tempY2 = Random.Range (-1 * (tempY), highY + 1);

		random_point2 = new Vector3 (tempX2, tempY2);

		Instantiate (wormhole, random_point1, Quaternion.identity);
		Instantiate (wormhole2, random_point2, Quaternion.identity);

	}
}
