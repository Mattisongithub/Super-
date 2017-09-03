using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EntityType {
	HOSTILE, NULL, ALLY, NEUTRAL
}



public class LivingEntity : MonoBehaviour {
	
	public static List<LivingEntity> allLivingEntities = new List<LivingEntity> (); 

	EntityType LivingEntityType = EntityType.NULL;
	string ID;
	int HealthInt;
	string Name;
	string CustomName;
	bool HasCustomName;
	bool HasPowers;
	bool PowersInUse;
	int Balance;

	// No comprendo!
	public Powers[] PowersBound = { Powers.Flight };

	public LivingEntity (EntityType ent, string id, string name, string customName, bool hascustomName, bool hasPowers, bool powerInUse, int healthInt, int balance) {
		LivingEntityType = ent;
		ID = id;
		if (healthInt != null)
			HealthInt = healthInt;
		Name = name;
		CustomName = customName;
		HasPowers = hasPowers;
		PowersInUse = powerInUse;
		Balance = balance;

		Power p = new Power (GetPowerInUse ().GetType ());
	}
		
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (this.GetType ().Equals (EntityType.NULL))
			return;
	}

	public bool GetPowerInUse() {
		return PowersInUse;
	}

	public void SetPowerInUse(bool toSet) {
		PowersInUse = toSet;
	}

	public string GetName() {
		return Name;
	}

	public Powers[] GetPowersInUse() {
		return PowersBound;
	}

	public void SetPowersInUse(Powers[] toSet) {
		PowersBound = toSet;
	}

	public int GetHealth() {
		return HealthInt;
	}

	public EntityType GetEntityType() {
		return LivingEntityType;
	}

	public string GetID() {
		return ID;
	}

	public void SetID(string id) {
		ID = id;
	}

	public void SetCategory(EntityType ent) {
		LivingEntityType = ent;
	}

	public int GetBalance () {
		return Balance;
	}
}