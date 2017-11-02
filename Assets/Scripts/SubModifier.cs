using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubModifier : ScriptableObject {

	public float cooldown;
	public float value;
	public float familyvalues;
	private float internalcooldown;

	public virtual void runSubAction(PlayerMovement samezies){
		familyvalues = 0;
	}

	public float getCooldown(){
		return cooldown;
	}

	public void changeValue(float x){
		value = x;
	}


}
