using UnityEngine;
using System.Collections;

public class GameStateManager : MonoSingleton<GameStateManager> {

	private GameState _current_game_state;

	public GameState CurrentGameState
	{
		get { return _current_game_state; }
	}

	public GameState initial_game_state;

	public void SetGameState(GameState gameState)
	{
		if (_current_game_state != null)
		{
			_current_game_state.EndState();
			_current_game_state.enabled = false;
		}

		_current_game_state = gameState;
		_current_game_state.BeginState();
		_current_game_state.enabled = true;
	}

	void Awake()
	{
		_current_game_state = initial_game_state;
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
		if (_current_game_state != null)
		{
			_current_game_state._update_state_();
		}

	}
}
