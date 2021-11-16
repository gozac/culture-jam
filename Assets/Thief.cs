using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : MonoBehaviour
{
	public UnityEngine.AI.NavMeshAgent agent;

	public GameObject target;

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
    // Start is called before the first frame update
    void Start()
    {
    	target = gameObject;
    	agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
    	Invoke("findtarget", 5);
    }

    // Update is called once per frame
    void Update()
    {/*
    	if (target && !target.active)
    		findtarget();*/
    	if (Input.GetKey(KeyCode.P)){
    		Debug.Log(target.transform.position);
        	agent.SetDestination(target.transform.position);
    	}
    	dist = Vector3.Distance(target.transform.position, transform.position);
    	Debug.Log(dist);
    	if (target != gameObject && dist < 1)
    		target.SetActive(false);
    }
}
