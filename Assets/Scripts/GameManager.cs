using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

	public Text subtitles;

	public Player player;
	public Text UI;
	public Text MoreUI;

	public GameObject hostPlayerGameObject;
	public PlayerStatus hostPlayerStatus;
	public string hostPlayerName;
	public string hostPlayerCustomName;
	public Powers hostPlayerPower;
	public bool hostPlayerUsingPower;
	public int hostPlayerHealth;
	public float hostPlayerCash;
	public float hostPlayerBank;


	// Use this for initialization
	void Start ()
	{
		subtitles.text = " ";
		Player p = new Player (hostPlayerGameObject, hostPlayerStatus, hostPlayerPower, hostPlayerName, hostPlayerCustomName, hostPlayerUsingPower, hostPlayerHealth, hostPlayerCash, hostPlayerBank);
		UI.text = UI.text.Replace ("%playername%", p.CustomName).Replace ("%power%", p.Power.ToString ());
		MoreUI.text = MoreUI.text.Replace ("%money%", p.GetTotalMoney ().ToString ()).Replace ("%date%", "Date");
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Ehhhhh
	}

	public void newPlayer (GameObject playerGameObject, PlayerStatus playerStatus, Powers playerPower, string playerName, string playerCustomName, bool playerUsingPower, int playerHealth, float playerCash, float playerBank) {
		player = new Player (playerGameObject, playerStatus, playerPower, playerName, playerCustomName, playerUsingPower, playerHealth, playerCash, playerBank);
		subtitles.text = player.CustomName + " has joined the game.";
	}
}

