using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class Economy : MonoBehaviour {

	public string currencySymbol = "$";
	public int moneyInCirculation;

	void Start () {
		moneyInCirculation = 0;
		foreach (LivingEntity livingEntity in LivingEntity.allLivingEntities) {
				moneyInCirculation = moneyInCirculation + livingEntity.GetBalance ();
		}
	}

	bool isLotteryOn;
	Dictionary<LivingEntity, int> lotteryNumbers = new Dictionary<LivingEntity, int> ();

	private void wat () {
		MethodInfo mi 
		Power p = new Power ("lotteryStarting", ;
	}

	public void startLottery () {
		if (isLotteryOn) {
			isLotteryOn = false;
		} else {
			isLotteryOn = true;
		}
	}

}
