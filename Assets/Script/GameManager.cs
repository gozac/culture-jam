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

	public static event Action<GameState> OnGameStateChanged;

	void Awake(){
		Instance = this;
	}


	public void UpdateGameState(GameState newstate){
		State = newstate;

		switch (newstate) {
			case GameState.Play:
				HandlePlay();
				break;
			case GameState.Lose:
				HandleLose();
				break;
			default:
				throw new ArgumentOutOfRangeException(nameof(newstate), newstate, null);
		}

		OnGameStateChanged?.Invoke(newstate);
	}

	void HandlePlay(){
		Debug.Log("Your turn");
	}

	void HandleLose(){
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
