using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SubModifiers/subShieldMod")]
public class subShieldMod : SubModifier {

	public GameObject sinwaveshield;

	public override void runSubAction (PlayerMovement xXx_pla_Move_xXx)
	{
		GameObject shield = Instantiate (sinwaveshield, xXx_pla_Move_xXx.transform.position, Quaternion.identity);
        shield.transform.parent = xXx_pla_Move_xXx.transform;
	}
}

