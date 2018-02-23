using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameOnStart : MonoBehaviour {
	public string filePath = "default";
	public SaveLoadUtility slu;
	//public SaveLoadMenu slm;
	public int secPassed;
	
	bool run = true;
	
	GameObject[] arr;
	
	void Update () {
		if(run){
			slu.LoadGame(filePath);
			run = false;
			/**int j = -1;
			for(int i = 0; i < slm.saveGames.Count; i ++){
				if(slm.saveGames.Get(i).SavegameName == "default"){
					j = i;
				}
			}*/
			
			arr = GameObject.FindGameObjectsWithTag("Bulb");
		
			if(arr.Length == 0){
				arr = GameObject.FindGameObjectsWithTag("Spawner");
				if(arr.Length == 0){
					SceneManager.LoadScene(1);
				}
			}
		}
		
		if(Input.GetKey(KeyCode.Escape))
			Application.Quit();
	}
	
	void OnApplicationFocus(){
		if (!run) {
			if (Application.isFocused) {
				Debug.Log ("Gained focus");
				slu.LoadGame (filePath);
			} else {
				Debug.Log ("Lost focus");
				slu.SaveGame (filePath);
			}
		}
	}
	void OnApplicationQuit(){
		if(!run)
			slu.SaveGame(filePath);
	}
	void OnApplicationPause(bool pauseStatus){
		if (pauseStatus) {
			Debug.Log ("Paused");
			slu.SaveGame (filePath);
		} else {
			Debug.Log ("Unpaused");
			slu.LoadGame (filePath);
		}
	}
}
