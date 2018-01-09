using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commander : MonoBehaviour {

	private Camera camera;
	public GameObject target;
	public GameObject camPosition;
	public GameObject trackingTarget;

	// Use this for initialization
	void Start () {
		camera = Camera.main;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			RaycastHit hit;
			Ray ray = camera.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out hit)) {
				//The expressions below either resolve to +1 or -1. Depending on which quadrant the hit lies in.
				int XMultiplier = (int)(Mathf.Abs(hit.point.x) / hit.point.x);
				int ZMultiplier = (int)(Mathf.Abs(hit.point.z)/hit.point.z);

				//Calculate the "snapped to grid" x-coord
				float newX = XMultiplier * (5f/6) + ((int)((hit.point.x)/(5f/3)))*(5f/3);
				float newY = hit.point.y;
				//Calculate the "snapped to grid" z-coord
				float newZ = ZMultiplier*(5f / 6) + ((int)((hit.point.z) / (5f / 3))) * (5f / 3);
				//Set newly clicked position
				target.transform.position = new Vector3(newX, newY, newZ);
			}
		}

		//If distance to location is too far away
		if(Vector3.Distance(transform.position, trackingTarget.transform.position)>= .01f) {
			float newX = Mathf.Lerp(transform.position.x, trackingTarget.transform.position.x, .1f);
			float newY = Mathf.Lerp(transform.position.y, trackingTarget.transform.position.y, .1f);
			float newZ = Mathf.Lerp(transform.position.z, trackingTarget.transform.position.z, .1f);
			transform.position = new Vector3(newX, newY, newZ);
		}

		if (Input.GetAxis("Vertical") != 0) {
			camPosition.transform.position = new Vector3(
				camPosition.transform.position.x,
				camPosition.transform.position.y,
				camPosition.transform.position.z + Input.GetAxis("Vertical"));
		}
		if (Input.GetAxis("Horizontal") != 0) {
			camPosition.transform.position = new Vector3(
				camPosition.transform.position.x + Input.GetAxis("Horizontal"),
				camPosition.transform.position.y,
				camPosition.transform.position.z);
		}

		if (Input.GetAxis("Rotate") != 0) {
			if (!alreadyRotated) {
				float rotation = 0;
				if (Input.GetAxis("Rotate") > 0)
					rotation = 1;
				else rotation = -1;
				camPosition.transform.rotation = new Quaternion(
					0,
					rotation,
					0,
					camPosition.transform.rotation.w);
				alreadyRotated = true;
				Debug.Log("rotating");
			}
		}else {
			alreadyRotated = false;
		}
	}

	bool alreadyRotated = false;
}
