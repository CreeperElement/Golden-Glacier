using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour {

	private Camera camera;

	// Use this for initialization
	void Start () {
		camera = Camera.main;
	}

	// Update is called once per frame
	void Update () {
		//Rotates the sprite so that it's always facing the camera; however it looks at it's own y position
		//to stop it from "falling over", when the camera passes over top of it.
		transform.LookAt(new Vector3(camera.transform.position.x, this.transform.position.y, camera.transform.position.z));
	}
}
