using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Soldier : MonoBehaviour {

	public GameObject targetPosition;
	public NavMeshAgent agent;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		agent.SetDestination(targetPosition.transform.position);
	}
}
