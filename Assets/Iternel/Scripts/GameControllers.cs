using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameControllers : MonoBehaviour
{
    public static GameControllers Instance { get; private set; }
    public event Action<bool> OnGameEnded;
    public event Action OnGameStarted;


    private void Awake () {
        Instance = this;
    }

    public void GameOver (bool isWin) {
        OnGameEnded?.Invoke (isWin);
    }

    public void RestartLevel () {
        SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
    }
    public void NextLevel () {
        GameVaarables.NextLevel ();
        RestartLevel ();
    }
    public void StartGame () {
        OnGameStarted?.Invoke ();
    }
}