﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : MonoBehaviour
{
	public UnityEngine.AI.NavMeshAgent agent;

	public GameObject target;

	public GameObject stolenObject;

	public Animator animComponent;

	float dist;

	void findtarget()
	{
		GameObject[] targets;
		targets = GameObject.FindGameObjectsWithTag("art");
		int index = Random.Range (0, targets.Length);
		if (targets == null)
				target = gameObject;
		if (targets[index].activeSelf)
			target = targets[index];
		else {
			foreach (GameObject cible in targets) {
				if (cible.activeSelf) {
					target = cible;
					break;
				}
			}
			if (target == null)
				target = gameObject;
		}
		agent.SetDestination(target.transform.position);
	}

	void findexit() {
		GameObject[] exits;
		exits = GameObject.FindGameObjectsWithTag("exit");
		int index = Random.Range (0, exits.Length);
		target = exits[index];
		agent.SetDestination(exits[index].transform.position);
	}

	void OnDestroy() {
		GameManager.Instance.Thiefs.Remove(gameObject);
		if (stolenObject)
			stolenObject.SetActive(true);
	}
    // Start is called before the first frame update
    void Start()
    {
    	target = gameObject;
    	agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
    	Invoke("findtarget", 2);
    }

    void getHit(GameObject opponent) {
    	transform.LookAt(opponent.transform);
    	animComponent.SetTrigger("die");
    	agent.isStopped = true;
    	Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {/*
    	if (target && !target.active)
    		findtarget();*/
    	if (stolenObject == null && target.activeSelf && target != gameObject && Vector3.Distance(target.transform.position, transform.position) < 1){
    		stolenObject = target;
    		target.SetActive(false);
    		gameObject.transform.Find("Particle System").gameObject.SetActive(true);
    		findexit();
    	} else if (stolenObject != null && Vector3.Distance(target.transform.position, transform.position) < 1) {
    		//leave
    		GameManager.Instance.StolenObjects.Add(stolenObject);
    		if(GameManager.Instance.StolenObjects.Count == GameManager.Instance.ArtObjects.Length){
    			GameManager.Instance.UpdateGameState(GameState.Lose);
    		}
    		gameObject.SetActive(false);
    	}
    }
}
