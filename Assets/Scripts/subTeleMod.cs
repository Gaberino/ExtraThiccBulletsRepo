using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "SubModifiers/subTeleMod")]
public class subTeleMod : SubModifier {

	public float tele_dist;
 	private Vector2 new_pos;

	public override void runSubAction (PlayerMovement xXx_pla_Move_xXx)
	{
		xXx_pla_Move_xXx.StartCoroutine(waitTime (xXx_pla_Move_xXx));
	}

	IEnumerator waitTime(PlayerMovement xXx_pla_Move_xXx){
		new_pos = xXx_pla_Move_xXx.transform.position + xXx_pla_Move_xXx.transform.up * tele_dist;
		SpriteRenderer active = xXx_pla_Move_xXx.GetComponent<SpriteRenderer> ();
		BoxCollider2D active2 = xXx_pla_Move_xXx.GetComponent<BoxCollider2D> ();
		active.enabled = false;
		active2.enabled = false;
		xXx_pla_Move_xXx.transform.position = new_pos;
		yield return new WaitForSeconds (0.2f);
		active.enabled = true;
		active2.enabled = true;
	}

}
