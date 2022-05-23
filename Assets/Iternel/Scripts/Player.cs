using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rigitBody;
    [SerializeField] private GameObject MovingPlatforms;
    [SerializeField] GameObject _uiController;
    private void Awake () {
        GameVaarables.GetPlatformCount ();
    }
    private void Start () {
        rigitBody = GetComponent<Rigidbody> ();
        rigitBody.isKinematic = true;

        GameControllers.Instance.OnGameStarted += GameStarted;
        GameControllers.Instance.OnGameEnded += GameEnded;
    }
    private void OnDestroy () {
        GameControllers.Instance.OnGameStarted -= GameStarted;
        GameControllers.Instance.OnGameEnded -= GameEnded;
    }
    private void OnCollisionEnter (Collision collision) {
        if (collision.gameObject.tag == "Platform")
        {
            var coins = collision.gameObject.GetComponent<Platform> ().GetCoinsCount (GameVaarables.CurrentCoins);
            GameVaarables.UpdateCoins (coins);
            _uiController.GetComponent<UIController> ().UpdateCount (coins.ToString ());
        }

        StopAllCoroutines ();
        StartCoroutine (Jump (collision));
    }
    private void Update () {
        if (transform.position.y < -5)
        {
            GameControllers.Instance.GameOver (false);
        }
    }
    private IEnumerator Jump (Collision col) {
        var time = 0f;
        var flyDuration = 1f;
        var startPos = transform.position;
        var finishPos1 = new Vector3 (0, GameVaarables.PlayerMaxJump, col.transform.position.z + GameVaarables.PlatformDelayRange / 2);
        

        while (time < flyDuration)
        {
            time += Time.deltaTime;
            transform.position = Vector3.Lerp (
                startPos,
                finishPos1,
                time / flyDuration);

            yield return null;
        }
        time = 0f;

        var tmp = MovingPlatforms.GetComponentsInChildren<Platform> ().Length;
        if (tmp >= 1)
        {
            var targetPlatform = MovingPlatforms.GetComponentsInChildren<Platform> ()[1];
            var finishPos2 = targetPlatform.transform.position;
            while (time < flyDuration)
            {
                time += Time.deltaTime;
                transform.position = Vector3.Lerp (
                    finishPos1,
                    finishPos2,
                    time / flyDuration);

                yield return null;
            }
        }
    }

    private void GameStarted () {
        rigitBody.isKinematic = false;
    }
    private void GameEnded (bool isWin) {
        rigitBody.isKinematic = true;
    }
}