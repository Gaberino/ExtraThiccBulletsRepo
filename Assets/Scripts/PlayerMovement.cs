using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    public float normalSpeed;
    /*
    public string inputControllerHorizontal;
    public string inputControllerVertical;
    public string inputControllerHorizontalLook;
    public string inputControllerVerticalLook;
    public string inputControllerFire;
    */
    public int playerNumber;

    [SerializeField] private PlayerInput myInput;

	public bool shootHeld = false;
    public bool strafeControls = false;

    public float timeAlive;
    public int killCount;
    public int currentLifeKillCount;
    public float respawnTime;
    public float iframes;
    public Text myScore;

    Rigidbody2D rbody;
    Vector3 moveDir;
    Vector3 lookDir;

    bool dead;
    public Transform explosionPrefab;

	private SpaceGun myPlayerGun;
    [SerializeField] private ShotModifier weapon1;
    public float weapExp1;
    [SerializeField] private ShotModifier weapon2;
    public float weapExp2;
    bool equip;

    public Transform upgradeObject;

    int powerMod = 1;

    public float dashTime;
    public float dashRecoverTime;
    public bool canDash;
    public bool dashing;

    Coroutine iframesRoutine;

	private SpriteRenderer mySR;
    [SerializeField] SpriteRenderer myTip;

	// Use this for initialization
	void Start () {
        myInput = this.GetComponent<PlayerInput>();
		myPlayerGun = this.GetComponent<SpaceGun>();
		mySR = this.GetComponent<SpriteRenderer>();
        rbody = GetComponent<Rigidbody2D>();
        dead = false;
        canDash = true;
        dashing = false;
        timeAlive = 0;
        weapExp1 = 0;
        weapExp2 = 0;
        myPlayerGun.currentShotMod = weapon1;
        equip = true;
	}
	
	// Update is called once per frame
	void Update () {
		// float shooting = Input.GetAxisRaw(inputControllerFire);
        if (!dead)
        {
			timeAlive += Time.deltaTime * (currentLifeKillCount + 1);
            if(upgradeObject != null)
            {
                if (equip) { weapExp1 += Time.deltaTime; }
                else { weapExp2 += Time.deltaTime; }
            }

            processMovement();
            processShooting();

            if (myInput.weaponSwapButtonPressed)
            {
                if (equip) { myPlayerGun.currentShotMod = weapon2; }
                else { myPlayerGun.currentShotMod = weapon1; }
                equip = !equip;
            }
        }
        myScore.text = myPlayerGun.currentShotMod.name + " Lv." + myPlayerGun.currentShotMod.currentLevel + " Kills: " + killCount;
	}

    void processShooting()
    {
        if (myInput.shootButtonHeld)
        {
            /*
            if (equip) { powerMod = Mathf.RoundToInt(weapExp1 / myPlayerGun.currentShotMod.timeToLevelRatio); }
            else { powerMod = Mathf.RoundToInt(weapExp2 / myPlayerGun.currentShotMod.timeToLevelRatio); }
            if (powerMod < 1) { powerMod = 1; }
            speed = normalSpeed / powerMod;
            if(speed < 1f) { speed = 1f; }
            */
            if (equip) { myPlayerGun.currentShotMod.ModifyAndShoot(weapExp1, myPlayerGun, mySR.color); }
            else { myPlayerGun.currentShotMod.ModifyAndShoot(weapExp2, myPlayerGun, mySR.color); }
        }
        /*
        else
        {
            speed = normalSpeed;
            powerMod = 1;
        }
        */
    }

    void processMovement()
    {
        rbody.velocity = Vector2.zero;
        float horizontal = myInput.leftStickInput.x;
        float vertical = myInput.leftStickInput.y;
        float horizontalLook = myInput.rightStickInput.x;
        float verticalLook = myInput.rightStickInput.y;

        Vector3 tempMoveDir = new Vector3(horizontal, vertical, 0);
        Vector3 tempLookDir = new Vector3(horizontalLook, verticalLook, 0f);

        float currSpeed = speed;

        if(!dashing)
        {
            if (horizontal != 0 || vertical != 0) { lookDir = tempMoveDir; }
            else if(horizontalLook != 0 || verticalLook != 0) { lookDir = tempLookDir; }
            if (tempLookDir.magnitude > 0)
            {
                // if (moveDir == Vector3.zero) { moveDir = tempMoveDir; }if(tempLookDir.x != 0 || tempLookDir.y != 0) 
                { transform.rotation = Quaternion.LookRotation(Vector3.forward, tempLookDir); }
                rbody.MovePosition(transform.position + tempMoveDir * speed * Time.deltaTime);
            }
            else
            {
                moveDir = tempMoveDir;
                transform.rotation = Quaternion.LookRotation(Vector3.forward, lookDir);
                rbody.MovePosition(transform.position + tempMoveDir * speed * Time.deltaTime);
            }
            if (myInput.dashButtonPressed && canDash) { StartCoroutine(dash()); }
        }
    }

    void processMovementDualStick()
    {
        /*
        rbody.velocity = Vector2.zero;
        float horizontal = Input.GetAxisRaw(inputControllerHorizontal);
        float vertical = Input.GetAxisRaw(inputControllerVertical);
        float horizontalLook = Input.GetAxisRaw(inputControllerHorizontalLook);
        float verticalLook = Input.GetAxisRaw(inputControllerVerticalLook);
        shootHeld = horizontalLook != 0 || verticalLook != 0;
        Vector3 tempFlyDir = new Vector3(horizontal, vertical, 0);
        Vector3 tempLookDir = new Vector3(horizontalLook, verticalLook, 0f);
        if (shootHeld)
        {
            if(tempLookDir.x != 0 || tempLookDir.y != 0) { transform.rotation = Quaternion.LookRotation(Vector3.forward, tempLookDir); }
        }
        else
        {
            if(tempFlyDir.x != 0 || tempFlyDir.y != 0) { transform.rotation = Quaternion.LookRotation(Vector3.forward, tempFlyDir); }
        }
        
        rbody.MovePosition(transform.position + tempFlyDir * speed * Time.deltaTime);
        */
    }

    public void Die(int killerID)
    {
        if(iframesRoutine == null)
        {
            if (killerID > 0 && killerID <= GameManager.Instance.players.Count)
            {
                PlayerMovement myKiller = GameManager.Instance.players[killerID - 1];
                myKiller.AddScore();
				if (killerID == 1)
					WinManager.instance.p1Kills += 1;
				else if (killerID == 2)
					WinManager.instance.p2Kills += 1;
            }
            weapExp1 = 0f;
            weapExp2 = 0f;
            currentLifeKillCount = 0;
            timeAlive = 0;
            dropUpgradeObject();
            StartCoroutine(respawn());
        }
    }

    IEnumerator respawn()
    {
        dead = true;
        Transform newExp = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(newExp.gameObject, 1f);
        // Deactivate collider(s) and spriterenderer(s)
        GetComponent<Collider2D>().enabled = false;
        mySR.enabled = false;
        myTip.enabled = false;
        yield return new WaitForSeconds(respawnTime);
        // reactivate collider(s) and spriterenderer(s)
        dead = false;
        transform.position = GameManager.Instance.getNewSpawnLoc(this);
        GetComponent<Collider2D>().enabled = true;
        mySR.enabled = true;
        myTip.enabled = true;
        iframesRoutine = StartCoroutine(freshSpawn());
    }

    public IEnumerator freshSpawn()
    {
        float startTime = Time.time;
        int frameCount = 0;
        while(Time.time - startTime < iframes)
        {
            if(frameCount%3 == 0) {
                mySR.enabled = !mySR.enabled;
                myTip.enabled = !myTip.enabled;
            }
            frameCount++;
            yield return new WaitForEndOfFrame();
        }
        mySR.enabled = true;
        myTip.enabled = true;
        iframesRoutine = null;
    }

    IEnumerator dash()
    {
        float startTime = Time.time;
        dashing = true;
        canDash = false;
        dropUpgradeObject();
        while(Time.time - startTime < dashTime)
        {
            rbody.velocity = lookDir * (speed * 3 + 0.1f * powerMod);
            yield return new WaitForEndOfFrame();
        }
        dashing = false;
        yield return new WaitForSeconds(dashRecoverTime);
        canDash = true;
    }

    public void AddScore()
    {
        killCount++;
        currentLifeKillCount++;
		myScore.text = "Lv." + myPlayerGun.currentShotMod.currentLevel + " Score: " + killCount.ToString();
    }

    public void pickUpWeapon(ShotModifier newShotMod)
    { // Replace currently held weapon and reset experience points
        if (equip) {
            if(weapon1 == newShotMod) { return; }
            weapon1 = newShotMod;
            weapExp1 = 0;
        }
        else {
            if (weapon2 == newShotMod) { return; }
            weapon2 = newShotMod;
            weapExp2 = 0;
        }
        myPlayerGun.currentShotMod = newShotMod;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.GetComponent<HoldToWinItem>() && upgradeObject == null)
        {
            pickUpUpgrader(coll.GetComponent<HoldToWinItem>());
        }
    }

    void pickUpUpgrader(HoldToWinItem upgrader)
    {
        if(upgrader.currentHolderTransform != null) { return; } // if someone's already holding this
        upgradeObject = upgrader.transform;
        upgrader.currentHolderTransform = transform;
        // upgradeObject.parent = transform;
        // upgradeObject.localPosition = Vector3.zero;
        // upgradeObject.GetComponent<Collider2D>().enabled = false;
    }

    void dropUpgradeObject()
    {
        if (upgradeObject != null)
        {
            // upgradeObject.GetComponent<Collider2D>().enabled = true;
            // upgradeObject.parent = null;
            upgradeObject.GetComponent<HoldToWinItem>().currentHolderTransform = null;
            upgradeObject = null;
        }
    }
}
