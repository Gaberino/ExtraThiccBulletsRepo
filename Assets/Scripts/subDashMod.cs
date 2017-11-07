using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "SubModifiers/subDashMod")]
public class subDashMod : SubModifier {
	
	public float multiplier;

	public override void runSubAction (PlayerMovement xXx_pla_Move_xXx)
	{
		Rigidbody2D rbody = xXx_pla_Move_xXx.rbody;
		Vector2 realLookDir = new Vector2 (xXx_pla_Move_xXx.lookDir.x, xXx_pla_Move_xXx.lookDir.y);
		rbody.MovePosition (rbody.position + realLookDir * xXx_pla_Move_xXx.speed * multiplier * Time.deltaTime);

	}

}

