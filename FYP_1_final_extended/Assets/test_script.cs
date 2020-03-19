using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class test_script : MonoBehaviour {
    private NavMeshAgent navAgent;
    public GameObject pos,player;

	// Use this for initialization
	void Start () {
        navAgent = GetComponent<NavMeshAgent>();
        
		
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(pos.transform.position);
        // navAgent.SetDestination(pos.transform.position);
        player = GameObject.FindWithTag("game object");
        //navAgent.SetDestination(player.transform.position);
    }
}
