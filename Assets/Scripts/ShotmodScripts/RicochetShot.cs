using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ShotModifiers/RichochetShot")]
public class RicochetShot : ShotModifier {

	public float perLevelBounceBonus;
	public float perLevelSpeedBonus = 1f;

	public override void ModifyAndShoot (float playerLife, SpaceGun originGun, Color bColor)
	{
		currentLevel = Mathf.RoundToInt(playerLife / timeToLevelRatio);
		if (currentLevel < 1) currentLevel = 1;
		if (maxUpgradeLevel != 0 && currentLevel > maxUpgradeLevel) currentLevel = maxUpgradeLevel;

		float cooldownToSet = shotCooldown;
		float scaleToSet = bulletScale;

		originGun.ShootBullet(bulletShootOffset, originGun.transform.up * (bulletSpeeds + (currentLevel * perLevelSpeedBonus)), bColor, bulletLifeTimes, cooldownToSet, scaleToSet, bulletSpriteToSet, true);
	}
}
