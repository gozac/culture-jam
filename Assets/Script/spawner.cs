using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
	public GameObject thief;

	public GameObject[] spawns;

	public int nbFoe;

	public int delay;

	public int chrono;

	private IEnumerator coroutine;

	int i = 0;

    // Start is called before the first frame update
    void Start()
    {
    	spawns = GameObject.FindGameObjectsWithTag("spawn");

    	coroutine = SpawnFoe();
        StartCoroutine(coroutine);
        
    }

    private IEnumerator SpawnFoe()
    {
        while (i < nbFoe)
        {
        	int index = Random.Range (0, spawns.Length);
            yield return new WaitForSeconds(delay);
            Instantiate(thief, spawns[index].transform.position, Quaternion.identity);
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
