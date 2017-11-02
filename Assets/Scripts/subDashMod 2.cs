using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "SubModifiers/DefaultModifier")]
public class subDashMod : SubModifier {

	public float cooldown;
	public float value;
	public float dashTime;
	public float speed;

	public GameObject myPlayer;

	public override void runSubAction (float new_cooldown, float new_value)
	{
		base.runSubAction (cooldown, value);

		Vector3 lookDir = new Vector3 (myPlayer.transform.localRotation);

		Rigidbody2D rbody = myPlayer.GetComponent<Rigidbody2D> ();

		PlayerMovement myMove = myPlayer.GetComponent<PlayerMovement> ();

		float startTime = Time.time;
		bool dashing = true;
		bool canDash = false;
		myMove.
		while(Time.time - startTime < dashTime)
		{
			rbody.velocity = lookDir * (speed * 3 + 0.1f * value);
			yield return new WaitForEndOfFrame();
		}
		dashing = false;
		yield return new WaitForSeconds(cooldown);
		canDash = true;
	}

}

