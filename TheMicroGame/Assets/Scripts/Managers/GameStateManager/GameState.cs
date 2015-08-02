using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public abstract class GameState : MonoBehaviour {
	
	protected GameState _parent_game_state;

	protected GameState _current_sub_game_state;

	public bool HasParent
	{
		get { return _parent_game_state != null; }
	}

	public GameState ParentGameState
	{
		get { return _parent_game_state; }
	}

	public bool HasSubGameState
	{
		get { return _current_sub_game_state != null; }
	}

	public GameState SubGameState
	{
		get { return _current_sub_game_state; }
	}

	public void Awake()
	{
		Initialize();
		enabled = false;
	}

	public void SetSubGameState(GameState gameState)
	{
		if (_current_sub_game_state != null)
		{
			_current_sub_game_state.EndState();
			_current_sub_game_state.enabled = false;
		}

		_current_sub_game_state = gameState;
		_current_sub_game_state.BeginState();
		_current_sub_game_state.enabled = true;
	}

	public abstract void Initialize();

	public abstract void BeginState();
	public abstract void EndState();
	public abstract void ResetState();

	public abstract void Game_Update();

	// do not use this method out side of the game state manager
	public void _update_state_()
	{
		Game_Update();
		if (_current_sub_game_state != null)
		{
			_current_sub_game_state._update_state_();
		}
	}
}
