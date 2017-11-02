using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubModifier : MonoBehaviour {

	public float cooldown;
	public float value;
	public float familyvalues;
	private float internalcooldown;

	public virtual void runSubAction(float new_cooldown, float new_value){
		cooldown = new_cooldown;
		value = new_value;
		familyvalues = 0;
	}

	public float getCooldown(){
		return cooldown;
	}

	public void changeValue(float x){
		value = x;
	}


}
