using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstLoadSpawner : MonoBehaviour {
	public GameObject bulbSelection;
	
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		Scene currentScene = SceneManager.GetActiveScene ();
        if (currentScene.buildIndex == 0) {
			Instantiate (bulbSelection);
			
			GameObject[] arr = GameObject.FindGameObjectsWithTag("Bulb");
			if(arr.Length > 0){
				SaveLoadUtility slu = GameObject.Find("Camera").GetComponent<SaveLoadUtility>();
				slu.SaveGame("default");
				Destroy(gameObject);
			}
        }
	}
}
