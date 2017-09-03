using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	

	public Player hostPlayer;
	public Dictionary<GameObject, Player> getPlayerFromGameObject = new Dictionary<GameObject, Player> ();

	void Start () {
		//hostPlayer = new Player (playerGameObject, playerStatus, playerPower, playerName, playerCustomName, playerUsingPower, playerHealth, playerCash, playerBank);
		//getPlayerFromGameObject.Add (playerGameObject, hostPlayer);
	}

	//public static Player GetPlayerFromGameObject (GameObject go) {
	//player
	//}
	
}
