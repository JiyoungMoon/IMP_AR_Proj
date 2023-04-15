using System;
using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    // State management
    public static GameManager _instance;
    public GameState state;
    public static event Action<GameState> OnGameStateChange;

    // Game Objects
    [SerializeField] private GameObject indicator;
    
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("Game Manager is NULL!");
            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        UpdateGameStates(GameState.Placement);
    }

    private void UpdateGameStates(GameState newState)
    {
        state = newState;
        Debug.Log("New Stage: " + state.ToString());

        switch (newState)
        {
            case GameState.Placement:
                HandleBeginPlacement();
                break;
            case GameState.Shooting:
                HandleBeginShooting();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameStateChange?.Invoke(newState);
    }

    public void ClickButtonPlace() {
        UpdateGameStates(GameState.Shooting);
        indicator.SetActive(false);
        
    }
    void HandleBeginPlacement()
    {
        indicator.SetActive(true);
    }

    void HandleBeginShooting()
    {
        print("Shooting available");
    }
}

public enum GameState
{
    Placement,
    Shooting
}