using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;

public enum PlayerStatus {
	Superhero, Supervillain, Vigilante, Unidentified
}

public class Player : MonoBehaviour {

	public List<GameObject> PlayerParents = new List<GameObject> (); 

	public GameObject PlayerGameObject;
	public PlayerStatus CurrentPlayerStatus = PlayerStatus.Unidentified;
	public int HealthInt = 100;
	public string Name = "Brad Pitt";
	public string CustomName = "The Bradinator"; 
	public bool hasCustomName = false;
	public bool hasPowers = false;
	public bool PowerInUse = false;
	public Powers Power = Powers.Flight;
	public float AmountInCash;
	public float AmountInBank;

	public Player (GameObject playerGameObject, PlayerStatus pst, Powers power, string name, string customName, bool powerInUse, int healthInt, float amountInCash, float amountInBank) {		
		PlayerGameObject = playerGameObject;
		Power = power;
		CurrentPlayerStatus = pst;
		HealthInt = healthInt;
		Name = name;
		CustomName = customName;
		PowerInUse = powerInUse;
		AmountInCash = amountInCash;
		AmountInBank = amountInBank;

		
		//ThirdPersonOrbitCam tupac = new ThirdPersonOrbitCam ();
		//tupac.player = newPlayer.transform;
	}

	public Powers GetPower() {
		return Power;
	}

	public GameObject GetGameObject () {
		return PlayerGameObject;
	}

	public bool IsPowerInUse () {
		return PowerInUse;
	}

	public void SetPower (Powers newPower) {
		Power = newPower;
	}

	public string GetName () {
		return Name;
	}

	public int GetHealth () {
		return HealthInt;
	}

	public PlayerStatus GetStatus () {
		return CurrentPlayerStatus;
	}

	public void SetPlayerStatus (PlayerStatus pst) {
		CurrentPlayerStatus = pst;
	}

	public float GetTotalMoney () {
		return AmountInBank + AmountInCash;
	}

	public float GetMoneyInBank () {
		return AmountInBank;
	}

	public float GetMoneyInCash () {
		return AmountInCash;
	}

	public void GiveMission (Mission mission) {
		
	}

	public void RevokeMission (Mission mission) {
		Destroy (mission);
	}

	public void Spawn () {
		GameObject newPlayer = Instantiate (GetGameObject ());
		newPlayer.name = name;
		PlayerGameObject = newPlayer;
		GameObject playerParent = new GameObject ();
		playerParent.name = name + " (Parent)";
		PlayerParents.Add (playerParent);
	}

	public string James () {
		return "Lynch";
	}

}