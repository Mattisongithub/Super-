using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PowerManager : MonoBehaviour {

	public bool isPowerInUse;
	public List<string> powers = new List<string>();
	
	//public static string chosenPower = "Super Strength";
	//public string playerPower;

	public Powers currentPower;

	void Start () {
		PlayerManager pm = new PlayerManager ();
		Player p = pm.hostPlayer;
		isPowerInUse = false;
		/*if (powers.Count = 0) {
			Debug.LogError ("No powers were found.\nStop the game immediately and install at least one power or Best Friend James Lynch will attack you."); 
		}*/
		DirectoryInfo info = new DirectoryInfo ("Assets/Powers/");
		FileInfo[] finfo = info.GetFiles ("*.meta");
		foreach (FileInfo f in finfo)
		{
			string pname = f.Name;
			powers.Add (pname.Replace (".meta", ""));
		}
	}

	void Update () {
		if (Input.GetButton ("Power")) {
			isPowerInUse = true;
		} else {
			isPowerInUse = false;
		}
	}
}

public enum Powers {

	Flight,			// 75%
	Super_Strength,	// 15%
	Invisibility,	// 0%
	Super_Speed,	// 30%
	Teleportation,	// 0%
	Telekinesis,	// 0%
	Mind_Control	// 0%

}