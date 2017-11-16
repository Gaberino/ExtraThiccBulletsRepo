using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ShotModifiers/TriangleShotMod")]
public class TriangleShotMod: ShotModifier {

	public float sideShotAngle = 5f;
	public float perLevelCooldownReduction = 1;

	public override void ModifyAndShoot (float playerLife, SpaceGun originGun, Color bColor)
	{
		currentLevel = Mathf.RoundToInt(playerLife / timeToLevelRatio);
		if (currentLevel < 1) currentLevel = 1;
		if (maxUpgradeLevel != 0 && currentLevel > maxUpgradeLevel) currentLevel = maxUpgradeLevel;

		float cooldownToSet = shotCooldown - (perLevelCooldownReduction * currentLevel);
		float scaleToSet = bulletScale + (perLevelSizeBonus * currentLevel);

		originGun.ShootBullet(bulletShootOffset, (originGun.transform.up * bulletSpeeds) + (originGun.transform.right * sideShotAngle), bColor, bulletLifeTimes, 0, scaleToSet, bulletSpriteToSet);
		//Debug.Log ("shot1");
		originGun.ShootBullet(bulletShootOffset, (originGun.transform.up * bulletSpeeds) + (originGun.transform.right * -sideShotAngle), bColor, bulletLifeTimes, 0, scaleToSet, bulletSpriteToSet);
		//Debug.Log ("shot2");
		originGun.ShootBullet(bulletShootOffset, originGun.transform.up * bulletSpeeds, bColor, bulletLifeTimes, cooldownToSet, scaleToSet, bulletSpriteToSet);
		//Debug.Log ("Shot3");
	}
}
