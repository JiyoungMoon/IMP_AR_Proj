using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    // Singleton
    private static MenuManager _instance;

    // UI Elements
    [SerializeField] private Button buttonPlace;
    [SerializeField] private TextMeshProUGUI textScore;

    public static MenuManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("Menu Manager is NULL!");
            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;

        // Subscribe to game manager
        GameManager.OnGameStateChange += HandleOnGameStateChanged;
        GameManager.OnScoreChange += HandleOnScoreChanged;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChange -= HandleOnGameStateChanged;
        GameManager.OnScoreChange -= HandleOnScoreChanged;
    }

    void HandleOnGameStateChanged(GameState state)
    {
        showPlacementButton(state == GameState.Placement);
    }
    void HandleOnScoreChanged(int score)
    {
        textScore.text = $"Score: {score}";
    }

    private void showPlacementButton(bool active)
    {
        buttonPlace.gameObject.SetActive(active);
    }
}
