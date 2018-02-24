using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSizeScaler : MonoBehaviour {
	Camera cam;

	// Use this for initialization
	void Start () {
		cam = GetComponent<Camera> ();
		cam.orthographicSize = 2.81109445f / Screen.width * Screen.height;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
