using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    // State management
    public static MenuManager _instance;

    [SerializeField] private Button buttonPlace;

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
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChange -= HandleOnGameStateChanged;
    }

    void HandleOnGameStateChanged(GameState state)
    {
        showPlacementButton(state == GameState.Placement);
    }

    private void showPlacementButton(bool active)
    {
        buttonPlace.gameObject.SetActive(active);
    }
}
