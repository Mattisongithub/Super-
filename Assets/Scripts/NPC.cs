using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Activity {
	HOUSE, PARK, SHOPS, WANDER
}

public class Routine : MonoBehaviour {

	public NPC npc_var;
	public Activity morningActivity;
	public Activity afternoonActivity;
	public Activity nightActivity;
	public Activity duringNightActivity;
	 
	public Routine (NPC npc, Activity morning, Activity afternoon, Activity night, Activity duringNight) {
		npc_var = npc;
		morningActivity = morning;
		afternoonActivity = afternoon;
		nightActivity = night;
		duringNightActivity = duringNight;
	}

}

public class DailyRoutine : MonoBehaviour {

	NPC npc_var;
	Routine mondayRoutine;
	Routine tuesdayRoutine;
	Routine wednesdayRoutine;
	Routine thursdayRoutine;
	Routine fridayRoutine;
	Routine saturdayRoutine;
	Routine sundayRoutine;

	public DailyRoutine (NPC npc, Routine monday, Routine tuesday, Routine wednesday, Routine thursday, Routine friday, Routine saturday, Routine sunday) {
		npc_var = npc;
		mondayRoutine = monday;
		tuesdayRoutine = tuesday;
		wednesdayRoutine = wednesday;
		thursdayRoutine = thursday;
		fridayRoutine = friday;
		saturdayRoutine = saturday;
		sundayRoutine = sunday;
	}

	public Routine GetRoutine (GameDay day) {
		if (day.Equals (GameDay.MONDAY)) {
			return mondayRoutine;
		} else if (day.Equals (GameDay.TUESDAY)) {
			return tuesdayRoutine;
		} else if (day.Equals (GameDay.WEDNESDAY)) {
			return wednesdayRoutine;
		} else if (day.Equals (GameDay.THURSDAY)) {
			return thursdayRoutine;
		} else if (day.Equals (GameDay.FRIDAY)) {
			return fridayRoutine;
		} else if (day.Equals (GameDay.SATURDAY)) {
			return saturdayRoutine;
		} else if (day.Equals (GameDay.SUNDAY)) {
			return sundayRoutine;
		} else {
			return null; // it's an enumerator and I've used all the values though soooooo...
		}
	}

}

public class NPC : MonoBehaviour {

	public List<string> notSmartDialogue = new List<string> ();
	GameManager gm = new GameManager ();

	string Name;
	bool _IsSmart;
	GameObject NPCGameObject;
	bool HasPowers;
	Powers Power;
	Dictionary<Player, int> FeelingsTowardPlayers;

	public NPC (string name, GameObject npcGameObject, bool isSmart, bool hasPowers, Powers power, Dictionary<Player, int> feelingsTowardPlayers, bool hasMission, Mission mission) {
		Name = name;
		NPCGameObject = npcGameObject;
		_IsSmart = isSmart;
		if (isSmart) {
			HasPowers = hasPowers;
			Power = power;
			Dictionary<Player, int> FeelingsTowardPlayers = feelingsTowardPlayers;
		}
	}

	public bool IsSmart () {
		if (_IsSmart)
			return true;
		else
			return false;
	}

	public void Say (string toSay, float time) {
		gm.subtitles.text = toSay;
		gm.subtitles.CrossFadeAlpha (1f, 1f, false);
		gm.subtitles.CrossFadeAlpha (0.9f, time, false);
		gm.subtitles.CrossFadeAlpha (0f, 1f, false);
	}

	public string GetDialogue () {
		if (this._IsSmart) {
			return notSmartDialogue [Random.Range (1, notSmartDialogue.Count)];
		} else {
			// TODO Smart NPC behaviour
			return "We are not smart enough yet! Please come back later!";
		}
	}

	public Camera GetCamera () {
		return GetGameObject ().GetComponent<Camera>();
	}

	public GameObject GetGameObject () {
		return null;
	}

	public bool CanSee (GameObject toSee) {
		var planes = GeometryUtility.CalculateFrustumPlanes (GetCamera ());
		foreach (Plane plane in planes) {
			float distance = plane.GetDistanceToPoint (toSee.transform.position);
			if (distance < 0f)
				return false;
		}
		return false;
	}

	public void SetDailyRoutine (DailyRoutine dailyRoutine) {
		
	}
		
}
