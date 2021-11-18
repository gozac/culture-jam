using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI(){
    	if (GameManager.Instance.ArtObjects.Length > 0){
    		int i = 0;
    		foreach (GameObject art in GameManager.Instance.ArtObjects) {
    			if (art.activeSelf)
    				i++;
    		}
    		GUI.Label(new Rect(10, 10, 100, 50), "Art: " + i + " / " + GameManager.Instance.ArtObjects.Length);


    	}
    }
}
