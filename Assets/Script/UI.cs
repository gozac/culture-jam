using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
	public string[] bref;

	public string[] win;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI(){
    	switch (GameManager.Instance.State) {
    		case GameState.Play:
    			if (GameManager.Instance.ArtObjects.Length > 0){
		    		int i = 0;
		    		foreach (GameObject art in GameManager.Instance.ArtObjects) {
		    			if (art.activeSelf)
		    				i++;
		    		}
		    		GUI.Label(new Rect(10, 10, 100, 50), "Art: " + i + " / " + GameManager.Instance.ArtObjects.Length);
	    		}
	    		break;
	    	case GameState.Pause:
	    		if (GUI.Button(new Rect(Screen.width - 100, Screen.height - 50, 200, 100), "Play")) {
	    			GameManager.Instance.UpdateGameState(GameState.Play);
	    		}
	    		break;
    	}
    }
}
