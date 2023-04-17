using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem.LowLevel;

public class GameManager : MonoBehaviour
{
    // State management
    private static GameManager _instance;
    public GameState state;
    public static event Action<GameState> OnGameStateChange;
    public static event Action<int> OnScoreChange;

    // Game Objects
    [SerializeField] private GameObject indicator;
    [SerializeField] private GameObject weapon;

    // Score
    private int score = 0;
    
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
        weapon.SetActive(false);
    }

    void HandleBeginShooting()
    {
        indicator.SetActive(false);
        weapon.SetActive(true);
        ProjectileManager.Instance.setBullet(0);
    }

    public void addScore(int points)
    {
        score += points;
        OnScoreChange?.Invoke(score);
    }
}

public enum GameState
{
    Placement,
    Shooting
}