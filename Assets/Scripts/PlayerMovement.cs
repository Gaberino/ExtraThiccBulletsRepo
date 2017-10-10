using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    public string inputControllerHorizontal;
    public string inputControllerVertical;
    public int playerNumber;

    Rigidbody2D rbody;

    public Transform myCamera;
    Quaternion myCameraInitRot;

    public Transform myShipBody;

	// Use this for initialization
	void Start () {
        rbody = GetComponent<Rigidbody2D>();
        myCameraInitRot = myCamera.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        myCamera.rotation = myCameraInitRot;
        float horizontal = Input.GetAxisRaw(inputControllerHorizontal);
        float vertical = Input.GetAxisRaw(inputControllerVertical);

        if(horizontal != 0 || vertical != 0)
        {
            Vector3 moveDir = new Vector3(horizontal, vertical, 0);
            rbody.MovePosition(transform.position + moveDir * speed * Time.deltaTime);
            // transform.rotation = Quaternion.LookRotation(Vector3.forward, moveDir);
            myShipBody.rotation = Quaternion.LookRotation(Vector3.forward, moveDir);
        }
	}
}
