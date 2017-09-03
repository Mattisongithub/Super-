using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;
using System.Threading;

public enum MissionTypes {
	COLLECT_ITEM, GIVE_TO, ASSASSINATE, 
}

public class Mission : MonoBehaviour {

	string MissionName;
	int ID;
	string MissionDescription;
	Player MissionGivenTo;
	NPC MissionGivenBy;
	string Date;

	public Mission (string missionName, string missionDescription, Player missionGivenTo, NPC missionGivenBy, string date) {
		MissionName = missionName;
		MissionDescription = missionDescription;
		MissionGivenTo = missionGivenTo;
		MissionGivenBy = missionGivenBy;
		Date = date;
	}

	public static string[] MissionNames = { "matt needs a nub", "matt hasa  nub", "who is matt" };
	public static System.Random randomGen = new System.Random();
	public static Mission generateRandomMission (Player givenTo, NPC givenBy) {
		string r_name = MissionNames[randomGen.Next (0, MissionNames.Length)];
		string r_desc = ""; 
		string r_date = "TODO";
		Mission mission = new Mission (r_name, r_desc, givenTo, givenBy, r_date);
		return mission;
	}
		
	public string GetName (Mission mission, Camera c) {
		return mission.MissionName;
	}

	public Mission GetMissionByID (int id) {
		Mission mission = null;
		return mission;
	}

	public int GetMissionID (Mission mission) { 
		return ID;
	}

	public void completeMission (Mission mission) {
		Destroy (mission);
	}

}
