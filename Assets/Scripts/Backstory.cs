using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backstory : MonoBehaviour {

	public static Backstory bstory;

	public string gender;
	public string verb;
	public string place;
	public string attacker;
	public string clothes;
	public string attacked;
	public string attackee;
	public string stole;
	public string stolen_item;

	void Start () {
		bstory = this;
	}

	public string backstory =
		"When I was a young " + bstory.gender + ", I was " + bstory.verb + " in " + bstory.place + ".\n" +
		"After " + bstory.verb + " for a while, a " + bstory.attacker + " wearing " + bstory.clothes + " jumped out of the bushes next to me and " + bstory.attacked +
		bstory.attackee + " and then stole my " + bstory.stolen_item + ".\n" +
		"I do not know who did this, because he was wearing " + bstory.clothes + " but I will get my revenge one day...";

}
