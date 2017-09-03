using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerDropdown : MonoBehaviour {

	public Dropdown dropdown;

	// Use this for initialization
	void Start () {
		PowerManager pm = new PowerManager ();
		dropdown.ClearOptions ();
		dropdown.AddOptions (pm.powers);
		dropdown.RefreshShownValue ();
	}
}
