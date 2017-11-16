using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "SubModifiers/subTeleMod")]
public class subTeleMod : SubModifier {
	private Vector2 telelocation;
	public float tele_dist;

	public override void runSubAction (PlayerMovement xXx_pla_Move_xXx)
	{
		Debug.Log (xXx_pla_Move_xXx.transform.up);
		xXx_pla_Move_xXx.transform.position += xXx_pla_Move_xXx.transform.up * tele_dist;


	}
}
