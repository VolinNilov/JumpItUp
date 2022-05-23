using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController Instance { get; private set; }

    public event System.Action<bool> onButtonPressed;

    [SerializeField] private GameObject GameOverlay;
    [SerializeField] private GameObject GameLooseOverlay;
    [SerializeField] private GameObject GameWinOverlay;
    [SerializeField] private GameObject MenuOverlay;

    [SerializeField] private Text CountText;

    public void UpdateCount (string count) {
        CountText.text = count;
    }

    private void Start () {
        GameControllers.Instance.OnGameEnded += GameOver;
        GameControllers.Instance.OnGameStarted += GameStarted;
    }
    private void OnDestroy () {
        GameControllers.Instance.OnGameEnded -= GameOver;
        GameControllers.Instance.OnGameStarted -= GameStarted;
    }
    private void Awake () {
        Instance = this;
    }

    public void ButtonPressed (bool isRight) {
        onButtonPressed?.Invoke (isRight);
    }

    public void GameOver (bool isWin) {
        GameOverlay.SetActive (false);
        if (isWin)
        {
            GameWinOverlay.SetActive (true);
            
        }
        else
        {
            GameLooseOverlay.SetActive (true);
        }
    }
    private void GameStarted () {
        MenuOverlay.SetActive (false);
        GameOverlay.SetActive (true);
    }
    public void GoMenu () {
        MenuOverlay.SetActive (true);
        GameOverlay.SetActive (false);
        GameLooseOverlay.SetActive (false);
        GameWinOverlay.SetActive (false);
    }
}