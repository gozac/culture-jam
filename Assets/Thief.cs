using System.Collections;
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
		if (targets[index].active)
			target = targets[index];
		else {
			foreach (GameObject cible in targets) {
				if (cible.active) {
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

    void getHit() {
    	animComponent.SetTrigger("die");
    	agent.isStopped = true;
    	Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {/*
    	if (target && !target.active)
    		findtarget();*/
    	if (stolenObject == null && target != gameObject && Vector3.Distance(target.transform.position, transform.position) < 1){
    		stolenObject = target;
    		target.SetActive(false);
    		findexit();
    	} else if (stolenObject != null && Vector3.Distance(target.transform.position, transform.position) < 1) {
    		//leave
    		gameObject.SetActive(false);
    	}
    }
}
