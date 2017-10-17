using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovementInControl : MonoBehaviour {

    public float speed;
//    public string inputControllerHorizontal;
//    public string inputControllerVertical;
//    public string inputControllerHorizontalLook;
//    public string inputControllerVerticalLook;
//    public string inputControllerFire;

	private PlayerInput myInput;
    public int playerNumber;
    
//	public bool shootHeld = false;
	public bool strafeControls = false;

    public float timeAlive;
    public int killCount;
    public int currentLifeKillCount;
    public float respawnTime;
    public Text myScore;

    Rigidbody2D rbody;
    Vector3 moveDir;
    Vector3 lookDir;

    bool dead;
    public Transform explosionPrefab;

	private SpaceGun myPlayerGun;
	private SpriteRenderer mySR;
	// Use this for initialization
	void Start () {
		myInput = this.GetComponent<PlayerInput> ();
		myPlayerGun = this.GetComponent<SpaceGun>();
		mySR = this.GetComponent<SpriteRenderer>();
        rbody = GetComponent<Rigidbody2D>();
        dead = false;
        timeAlive = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//float shooting = Input.GetAxisRaw(inputControllerFire);
        if (!dead)
        {
			timeAlive += Time.deltaTime * (currentLifeKillCount + 1);

            if (strafeControls)
            {
                //shootHeld = (shooting != 0);
                //processMovement();
            }
            else
            {
                processMovementDualStick();
            }
			if (myInput.shootButtonHeld) myPlayerGun.currentShotMod.ModifyAndShoot(timeAlive, myPlayerGun, mySR.color);
        }
	}

//    void processMovement()
//    {
//        rbody.velocity = Vector2.zero;
//        float horizontal = Input.GetAxisRaw(inputControllerHorizontal);
//        float vertical = Input.GetAxisRaw(inputControllerVertical);
//
//        Vector3 tempMoveDir = new Vector3(horizontal, vertical, 0);
//
//        if (shootHeld)
//        {
//            if (moveDir == Vector3.zero) { moveDir = tempMoveDir; }
//            transform.rotation = Quaternion.LookRotation(Vector3.forward, tempMoveDir);
//        }
//        else
//        {
//            if(horizontal != 0 || vertical != 0) { lookDir = tempMoveDir; }
//            moveDir = tempMoveDir;
//            transform.rotation = Quaternion.LookRotation(Vector3.forward, lookDir);
//        }
//        rbody.MovePosition(transform.position + moveDir * speed * Time.deltaTime);
//    }

    void processMovementDualStick()
    {
        rbody.velocity = Vector2.zero;
		float horizontal = myInput.leftStickInput.x;
		float vertical = myInput.leftStickInput.y;
		float horizontalLook = myInput.rightStickInput.x;
		float verticalLook = myInput.rightStickInput.y;
        //shootHeld = horizontalLook != 0 || verticalLook != 0;
        Vector3 tempFlyDir = new Vector3(horizontal, vertical, 0);
        Vector3 tempLookDir = new Vector3(horizontalLook, verticalLook, 0f);
		if (tempLookDir.magnitude > 0) //if there is stick input, look towards it
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, tempLookDir); 
        }
        else //otherwise look where you're flying
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, tempFlyDir); 
        }
        
        rbody.MovePosition(transform.position + tempFlyDir * speed * Time.deltaTime);
    }

    public void Die(int killerID)
    {
        if(killerID > 0 && killerID <= GameManager.Instance.players.Count)
        {
            PlayerMovement myKiller = GameManager.Instance.players[killerID - 1];
            myKiller.AddScore();
        }
        currentLifeKillCount = 0;
        timeAlive = 0;
        StartCoroutine(respawn());
    }

    IEnumerator respawn()
    {
        dead = true;
        Transform newExp = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(newExp.gameObject, 1f);
        // Deactivate collider(s) and spriterenderer(s)
        yield return new WaitForSeconds(respawnTime);
        // reactivate collider(s) and spriterenderer(s)
        dead = false;
        transform.position = GameManager.Instance.playerSpawns[playerNumber - 1].position;
    }

    public void AddScore()
    {
        killCount++;
        currentLifeKillCount++;
		myScore.text = "Lv." + myPlayerGun.currentShotMod.currentLevel + " Score: " + killCount.ToString();
    }

//    void OnCollisionEnter2D(Collision2D coll)
//    {
//        int killerID = -1;
//        if(coll.collider.tag == "Bullet")
//        {
//            // killerID = coll.collider.GetComponent<Bullet>().owner;
//        }
//        Die(killerID);
//    }
}
