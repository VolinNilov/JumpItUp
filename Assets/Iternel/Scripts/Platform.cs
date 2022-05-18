using System.Collections;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private GameObject PlatformSpawner;
    private bool isTaked = false;
    [SerializeField] private int maxRandomRotation;


    private void Start () {
        PlatformSpawner = GameObject.FindWithTag ("Spawner");
        transform.eulerAngles = new Vector3 (0, 0, Random.Range (-maxRandomRotation, maxRandomRotation));
        UIController.Instance.onButtonPressed += Rotate;

        GameControllers.Instance.OnGameEnded += GameOver;
    }
    private void OnDestroy () {
        GameControllers.Instance.OnGameEnded -= GameOver;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag ("Player"))
            return;

        isTaked = true;
        transform.parent = null;
        PlatformSpawner.GetComponent<PlatformSpavner> ().Spawn ();
        StartCoroutine (PlatformDeleter ());
    }
    private void Rotate (bool isRight) {
        if (isTaked) return;

        var c = 1;
        if (!isRight) c = -1;

        transform.Rotate (new Vector3 (0, 0, c * GameVaarables.RotationSpeed));
    }
    private IEnumerator PlatformDeleter()
    {
        yield return new WaitForSeconds(GameVaarables.DeletingTime);
        Destroy(this.gameObject);
    }

    private void GameOver (bool isWin) {
        StopAllCoroutines ();
        Destroy (gameObject);
    }
}