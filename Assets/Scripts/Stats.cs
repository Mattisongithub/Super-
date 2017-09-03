using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

	public float strengthStat;
	public float defenceStat;
	public float dexterityStat;
	public float constitutionStat;
	public float cookingStat;
	public float fishingStat;

	public Dictionary<string, float> strength = new Dictionary<string, float>(); // STR: Strength, how hard a player hits
	public Dictionary<string, float> defence = new Dictionary<string, float>(); // DEF: Defence, how many hits a player can take
	public Dictionary<string, float> dexterity = new Dictionary<string, float>(); // DEX: The agility, reflexes, and speed of a player
	public Dictionary<string, float> constitution = new Dictionary<string, float>(); // CON: The stamina and endurance of a player

	public Player player;

	void Start () {
		strength.Add (gameObject.name, strengthStat);
		defence.Add (gameObject.name, defenceStat);
		dexterity.Add (gameObject.name, dexterityStat);
		constitution.Add (gameObject.name, constitutionStat);
	}

	void Update () {
		if (player.GetHealth () <= 0) {
			// Player is dead! :(
				Destroy (player);
		}
	}
	
}
