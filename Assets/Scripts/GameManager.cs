using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    #region Global variables
    public static GameManager Instance;
    public bool gameRunning;

    #region Player Related Variables

    public List<PlayerMovement> players = new List<PlayerMovement>();
    public int playerCount;
    public PlayerMovement playerPrefab;
    public Transform[] playerSpawns;

    #endregion

    #region UI Stuff

    public GameObject scoreBoard;
    public GameObject playerScoreCard;

    #endregion

    #endregion

    #region Start and Update
    // Use this for initialization
    void Start () {
        Instance = this;
        if (gameRunning)
        {
            for(int i = 0; i < playerCount; i++)
            {
                if(i >= playerSpawns.Length) { break; }
                PlayerMovement newPlayer = Instantiate(playerPrefab, playerSpawns[i].position, Quaternion.identity);
                players.Add(newPlayer);
                newPlayer.playerNumber = players.Count;
                newPlayer.inputControllerHorizontal = "Horizontal_P" + newPlayer.playerNumber;
                newPlayer.inputControllerVertical = "Vertical_P" + newPlayer.playerNumber;
                newPlayer.inputControllerFire = "Shoot_P" + newPlayer.playerNumber;
                newPlayer.transform.name = "Player " + newPlayer.playerNumber;
                newPlayer.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0.5f, 0.8f), Random.Range(0.5f, 0.8f), Random.Range(0.5f, 0.8f));
                GameObject newScoreCard = Instantiate(playerScoreCard);
                newScoreCard.transform.SetParent(scoreBoard.transform, false);
                newPlayer.myScore = newScoreCard.GetComponent<Text>();
                newPlayer.myScore.text = "0";
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R)) { SceneManager.LoadScene(SceneManager.GetActiveScene().name); }
	}
    #endregion
}
