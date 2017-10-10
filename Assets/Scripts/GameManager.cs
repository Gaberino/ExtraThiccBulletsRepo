using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    #region Global variables
    public static GameManager Instance;
    public bool gameRunning;

    #region Player Related Variables
    public List<PlayerMovement> players = new List<PlayerMovement>();

    [Range(1, 4)]
    public int playerCount;
    public PlayerMovement playerPrefab;

    public Transform[] playerSpawns;
    #endregion

    #endregion

    #region Start and Update
    // Use this for initialization
    void Start () {
        Instance = this;
        if (gameRunning)
        {
            for (int i = 0; i < playerCount; i++)
            {
                PlayerMovement newPlayer = Instantiate(
                    playerPrefab, playerSpawns[Random.Range(0, playerSpawns.Length)].position, Quaternion.identity);
                players.Add(newPlayer);
                newPlayer.playerNumber = players.Count;
                newPlayer.transform.name = "Player " + newPlayer.playerNumber;
                newPlayer.inputControllerHorizontal = "Horizontal_P" + newPlayer.playerNumber;
                newPlayer.inputControllerVertical = "Horizontal_P" + newPlayer.playerNumber;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    #endregion
}
