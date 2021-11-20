using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
	public string[] bref;

	public string[] win;

	public string[] lose;

	int iBref;

	int iWin;

	int iLose;

	string next = "Suivant";
    // Start is called before the first frame update
    void Start()
    {
    	iBref = 0;
    	iWin = 0;
    	iLose = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI(){
    	switch (GameManager.Instance.State) {
    		case GameState.Bref:
    			if (iBref == bref.Length){
    				GameManager.Instance.UpdateGameState(GameState.Play);
    				break;
    			}
    			GUILayout.Box(bref[iBref]);
    			if (GUI.Button(new Rect(Screen.width - 110, Screen.height - 60, 100, 50), "Suivant")) {
    				iBref++;
    			}
    			break;
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
	    		if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "Play")) {
	    			GameManager.Instance.UpdateGameState(GameState.Play);
	    		}
	    		break;
	    	case GameState.Win:
    			GUILayout.Box(win[iWin]);
    			if (GUI.Button(new Rect(Screen.width - 110, Screen.height - 60, 100, 50), next)) {
    				iWin++;
    				if (iWin == win.Length)
    					SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    			}
    			break;
    		case GameState.Lose:
    			GUILayout.Box(lose[iLose]);
    			if (GUI.Button(new Rect(Screen.width - 110, Screen.height - 60, 100, 50), next)) {
    				iLose++;
    				if (iLose == lose.Length)
    					SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    			}
    			break;
    	}
    }
}
