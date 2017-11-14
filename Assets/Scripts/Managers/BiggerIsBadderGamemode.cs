using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "GameModes/BiggerIsBadderGameMode")]
public class BiggerIsBadderGamemode : GameMode {


	public float smallGuyKillBonus;
	public float bigGuyKillPenalty;

	public int currentSmallGuy = 0;

	public float bigStartExp = 20;
	public float bigOnBigExp = 4;

	public float pointsPerSecondAsSmall;
	private float internalTimer = 0f;

	public override void StartPhase ()
	{
		base.StartPhase ();
		//this is where I would set core upgrade rate...IF I HAD ONE
		currentSmallGuy = 0;
	}

	public override void MainPhase ()
	{
		base.MainPhase ();
		if (currentSmallGuy != 0) {
			for (int i = 0; i < m_players.Count; i++) {
				if (i + 1 != currentSmallGuy) {
					if (m_players [i].weapExp < bigStartExp)
						m_players [i].weapExp = bigStartExp;
				} else {
					m_players [i].weapExp = 0f;
				}
				if (m_playerScores[i] < 0)
					m_playerScores[i] = 0;
			}

			internalTimer += Time.deltaTime;
			if (internalTimer > 1f) {
				m_playerScores [currentSmallGuy - 1] += pointsPerSecondAsSmall;
				internalTimer = 0f;
			}
		}
	}

	public override void Addscore (int playerNum, PlayerMovement killedPlayer)
	{
		if (killedPlayer.playerNumber != currentSmallGuy && currentSmallGuy > 0) {
			m_playerScores [killedPlayer.playerNumber - 1] -= bigGuyKillPenalty;
			if (playerNum != currentSmallGuy)
				m_players [playerNum - 1].weapExp += bigOnBigExp;
			killedPlayer.weapExp = bigStartExp;
		} else if (currentSmallGuy == 0) {
			currentSmallGuy = playerNum;
		}
		else {
			m_playerScores[playerNum - 1] += smallGuyKillBonus;
			currentSmallGuy = playerNum;
			m_players [playerNum - 1].weapExp = 0f;
			killedPlayer.weapExp = bigStartExp;
		}
	}
}
