using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;

	public GameState State;

	public GameObject[] ArtObjects;

	public List<GameObject> StolenObjects;

	public List<GameObject> Thiefs = new List<GameObject>();

	public static event Action<GameState> OnGameStateChanged;

	void Awake(){
		Instance = this;
	}


	public void UpdateGameState(GameState newstate){
		State = newstate;

		switch (newstate) {
			case GameState.MainMenu:
				HandleMainMenu();
				break;
			case GameState.Bref:
				HandleBref();
				break;
			case GameState.Play:
				HandlePlay();
				break;
			case GameState.Pause:
				HandlePause();
				break;
			case GameState.Win:
				HandleWin();
				break;
			case GameState.Lose:
				HandleLose();
				break;
			default:
				throw new ArgumentOutOfRangeException(nameof(newstate), newstate, null);
		}

		OnGameStateChanged?.Invoke(newstate);
	}

	void HandleMainMenu(){
		Debug.Log("Welcome");
	}

	void HandleBref(){
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		Time.timeScale = 0;
		Debug.Log("Breafing");
	}

	void HandlePlay(){
		Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
		Debug.Log("Your turn");
	}

	void HandlePause(){
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		Time.timeScale = 0;
		Debug.Log("Stop");
	}

	void HandleWin(){
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		Time.timeScale = 0;
		Debug.Log("Bien joué");
	}

	void HandleLose(){
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		Time.timeScale = 0;
		Debug.Log("You lose");
	}

    // Start is called before the first frame update
    void Start()
    {
        UpdateGameState(GameState.Bref);
        ArtObjects = GameObject.FindGameObjectsWithTag("art");
    }

    // Update is called once per frame
    void Update()
    {
        if (State == GameState.Play){

        }
    }
}

public enum GameState {
	MainMenu,
	Bref,
	Play,
	Pause,
	Win,
	Lose
}
