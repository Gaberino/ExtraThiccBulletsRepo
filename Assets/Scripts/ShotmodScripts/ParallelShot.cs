using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ShotModifiers/ParallelShot")]
public class ParallelShot : ShotModifier {

	public int perLevelShotBonus = 1;
	public float perLevelCooldownReduction = 1;
	public float spreadAmount = .2f;

	public override void ModifyAndShoot (float playerLife, SpaceGun originGun, Color bColor)
	{
		base.ModifyAndShoot(playerLife, originGun, bColor);

		float cooldownToSet = shotCooldown - (perLevelCooldownReduction * currentLevel);
		float scaleToSet = bulletScale + (perLevelSizeBonus * currentLevel);

		int numToShoot = currentLevel * perLevelShotBonus;

		for (int i = -numToShoot / 2; i < numToShoot / 2; i++){
			if (i < (numToShoot / 2) - 1)
				originGun.ShootBullet(bulletShootOffset + (Vector2.right * (spreadAmount + scaleToSet / 2) * i), originGun.transform.up * bulletSpeeds, bColor, bulletLifeTimes, 0, scaleToSet, bulletSpriteToSet);
			else originGun.ShootBullet(bulletShootOffset + (Vector2.right * (spreadAmount + scaleToSet / 2) * i), originGun.transform.up * bulletSpeeds, bColor, bulletLifeTimes, cooldownToSet, scaleToSet, bulletSpriteToSet);
		}
	}
}
