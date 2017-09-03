using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class Power : MonoBehaviour {

    string powerName;

    public Power (string name, MethodInfo info) {
        powerName = name;
        info.Invoke (null, null);
    }
}
