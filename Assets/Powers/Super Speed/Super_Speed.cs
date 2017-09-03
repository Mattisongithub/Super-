using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class Super_Speed : MonoBehaviour {

	PowerManager pm = new PowerManager ();
	ThirdPersonCharacter tpc = new ThirdPersonCharacter ();
	float originalSpeed;

	void Update () {
		if (pm.isPowerInUse && pm.currentPower.Equals (Powers.Super_Speed)) {
			originalSpeed = tpc.m_MoveSpeedMultiplier;
			tpc.m_MoveSpeedMultiplier = 5f;
		} else {
			tpc.m_MoveSpeedMultiplier = originalSpeed;
		}
	}

	//TODO Possibly add time slow down?

}
