using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;

	public GameState State;

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
			default:
				throw new ArgumentOutOfRangeException(nameof(newstate), newstate, null);
		}

		OnGameStateChanged?.Invoke(newstate);
	}

	void HandlePlay(){
		
	}

    // Start is called before the first frame update
    void Start()
    {
        UpdateGameState(GameState.Play);
    }

    // Update is called once per frame
    void Update()
    {
        
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
