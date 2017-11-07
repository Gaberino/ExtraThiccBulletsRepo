using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "GameModes/DavidsAndGoliathGameMode")]
public class DavidsAndGoliathGameMode : GameMode {


	public float davidKillPoints;
	public float goliathKillPoints;

	public int currentGoliath = 0;

	public float expPerDavidOnDavid;

	public override void StartPhase ()
	{
		base.StartPhase ();
		//this is where I would set core upgrade rate...IF I HAD ONE
		currentGoliath = 0;
	}

	public override void MainPhase ()
	{
		base.MainPhase ();
		if (currentGoliath != 0) {
			m_players [currentGoliath - 1].weapExp = 10000f;
		}
	}

	public override void Addscore (int playerNum, PlayerMovement killedPlayer)
	{
		if (killedPlayer.playerNumber != currentGoliath) {
			m_playerScores [playerNum - 1] += davidKillPoints;
			//m_players [playerNum - 1].weapExp += expPerDavidOnDavid;
			killedPlayer.weapExp = 0f;
		} else if (currentGoliath == 0) {
			currentGoliath = playerNum;
			m_players [playerNum - 1].weapExp = 10000f;
		}
		else {
			m_playerScores[playerNum - 1] += goliathKillPoints;
			currentGoliath = playerNum;
			m_players [playerNum - 1].weapExp = 10000f;
			killedPlayer.weapExp = 0f;
		}
	}
}

