using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstLoadBulbOptions : MonoBehaviour {
	public GameObject bulb;
	public FirstLoadSpawner spawner;
	
	void OnMouseDown(){
		spawner.bulbSelection = bulb;
		SceneManager.LoadScene(0);
	}
}
