using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    public string inputControllerHorizontal;
    public string inputControllerVertical;
    public string inputControllerFire;
    public int playerNumber;
    
	public bool shootHeld = false;

    public float timeAlive;
    public int killCount;
    public int currentLifeKillCount;
    public float respawnTime;
    public Text myScore;

    Rigidbody2D rbody;
    Vector3 moveDir;

    bool dead;
    public Transform explosionPrefab;

	private SpaceGun myPlayerGun;
	private SpriteRenderer mySR;
	// Use this for initialization
	void Start () {
		myPlayerGun = this.GetComponent<SpaceGun>();
		mySR = this.GetComponent<SpriteRenderer>();
        rbody = GetComponent<Rigidbody2D>();
        dead = false;
        timeAlive = 0;
	}
	
	// Update is called once per frame
	void Update () {
		float shooting = Input.GetAxisRaw(inputControllerFire);
        if (!dead)
        {
			timeAlive += Time.deltaTime * (currentLifeKillCount + 1);

			shootHeld = (shooting != 0);
			if (shootHeld) myPlayerGun.currentShotMod.ModifyAndShoot(timeAlive, myPlayerGun, mySR.color);

            processMovement();
        }
	}

    void processMovement()
    {
        rbody.velocity = Vector2.zero;
        float horizontal = Input.GetAxisRaw(inputControllerHorizontal);
        float vertical = Input.GetAxisRaw(inputControllerVertical);

        Vector3 tempMoveDir = new Vector3(horizontal, vertical, 0);

        if (shootHeld)
        {
            if (moveDir == Vector3.zero) { moveDir = tempMoveDir; }
            transform.rotation = Quaternion.LookRotation(Vector3.forward, tempMoveDir);
        }
        else
        {
            moveDir = tempMoveDir;
            transform.rotation = Quaternion.LookRotation(Vector3.forward, moveDir);
        }
        rbody.MovePosition(transform.position + moveDir * speed * Time.deltaTime);
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
		myScore.text = "Lv." + myPlayerGun.currentShotMod.currentLevel + "Score: " + killCount.ToString();
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
