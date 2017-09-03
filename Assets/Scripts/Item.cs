using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Material { // TODO I TELL YOU! TODO TODO TODO!
    // WEAPONS:
    KNIFE, SWORD, BROADSWORD, BATTLEAXE, 

    // POTIONS:
    ANTIDOTE, STAMINUP,

    // KEY ITEMS:

    
    // GEMSTONES:
    DIAMOND, RUBY, OPAL, PEARL
    
}
public class Item {

    Material stackMaterial;
    int stackAmount;
    string stackName;

    public Item (Material material) {
        stackMaterial = material;
        stackAmount = 1;
        stackName = material.ToString ();
    }

    public Item (Material material, int amount) {
        stackMaterial = material;
        stackAmount = amount;
        stackName = material.ToString ();
    }  

    public Item (Material material, int amount, string name) {
        stackMaterial = material;
        stackAmount = amount;
        stackName = name;
    }    

}
