using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "GameModes/DavidsAndGoliathGameMode")]
public class DavidsAndGoliathGameMode : GameMode {


	public float davidOnDavidKillPoints;
	public float goliathOnDavidKillPoints;
	public float goliathKillPoints;

	public int currentGoliath = 0;

	public float expPerDavidOnDavid;

	public SubModifier davidSub;
	public SubModifier goliathSub;

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
		if (killedPlayer.playerNumber != currentGoliath && currentGoliath != 0) { //david on david or goliath on david
			
			//m_players [playerNum - 1].weapExp += expPerDavidOnDavid;
			killedPlayer.weapExp = 0f;
			CamControl.instance.AddShake((float)killedPlayer.weap.GetLevel(killedPlayer.weapExp));
			CamControl.instance.BlastBloom((float)killedPlayer.weap.GetLevel(killedPlayer.weapExp));


			m_playerScores [playerNum - 1] += davidOnDavidKillPoints;
			m_players[playerNum - 1].myCanvasManager.PopupMessage("+" + davidOnDavidKillPoints, .5f, .25f, 1f, 1.2f); 
		} else if (currentGoliath == 0) { //first kill
			CamControl.instance.AddShake((float)killedPlayer.weap.GetLevel(killedPlayer.weapExp));
			CamControl.instance.BlastBloom((float)killedPlayer.weap.GetLevel(killedPlayer.weapExp));
			currentGoliath = playerNum;
			m_players [playerNum - 1].weapExp = 10000f;
			m_playerScores [playerNum - 1] += davidOnDavidKillPoints;
			m_players[playerNum - 1].myCanvasManager.PopupMessage("IT BEGINS", .25f, 1f, 1f, 1f);
			m_players[playerNum - 1].sub = goliathSub;
		}
		else { //david kills goliath
			m_playerScores[playerNum - 1] += goliathKillPoints;
			currentGoliath = playerNum;
			m_players [playerNum - 1].weapExp = 10000f;
			CamControl.instance.AddShake((float)killedPlayer.weap.GetLevel(killedPlayer.weapExp));
			CamControl.instance.BlastBloom((float)killedPlayer.weap.GetLevel(killedPlayer.weapExp));
			killedPlayer.weapExp = 0f;
			m_players[playerNum - 1].myCanvasManager.PopupMessage("" + goliathKillPoints, .25f, 1f, 1f, 1f);
			m_players[playerNum - 1].sub = goliathSub;
			killedPlayer.sub = davidSub;
		}
	}
}

