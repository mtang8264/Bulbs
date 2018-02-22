using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	BulbStat bulbStat;
	Text nameText;
	Text infoText;

	Transform hungerBar;
	Transform thirstBar;
	Transform sleepBar;
	
	// Update is called once per frame
	void Update () {
		
		if (bulbStat == null) {
			bulbStat = GameObject.FindWithTag ("Bulb").GetComponent<BulbStat> ();
			nameText = GameObject.Find ("UIName").GetComponent<Text>();
			infoText = GameObject.Find ("UIInfo").GetComponent<Text>();
			hungerBar = GameObject.Find ("Hunger/BarFill").GetComponent<Transform> ();
			thirstBar = GameObject.Find ("Thirst/BarFill").GetComponent<Transform> ();
			sleepBar = GameObject.Find ("Sleep/BarFill").GetComponent<Transform> ();
		}
		nameText.text = bulbStat.bulbName;
		infoText.text = bulbStat.magic + "\n" + bulbStat.gender;

		hungerBar.localScale = (new Vector3 (bulbStat.hunger [1], 1f, 1f));
		thirstBar.localScale = (new Vector3 (bulbStat.thirst [1], 1f, 1f));
		sleepBar.localScale =  (new Vector3 (bulbStat.sleep [1], 1f, 1f));
	}
}
