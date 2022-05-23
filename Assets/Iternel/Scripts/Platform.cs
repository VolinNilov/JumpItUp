using System.Collections;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private GameObject EndModel;
    [SerializeField] private GameObject DefaultModel;
    public string type { get; private set; }

    private GameObject PlatformSpawner;
    private bool isTaked = false;
    private bool isEnd = false;

    [SerializeField] private int maxRandomRotation;

    public void SetFinish () {
        isEnd = true;
        isTaked = true;
        transform.eulerAngles = new Vector3 (0, 0, 0);

        DefaultModel.SetActive (false);
        EndModel.SetActive (true);
    }
    private void SetType () {
        var rnd = Random.Range (1, 4);
        switch (rnd)
        {
            case 1:
                type = $"+_{Random.Range(1, GameVaarables.MaxAlgIncrement)}";
                break;
            case 2:
                type = $"-_{Random.Range (1, GameVaarables.MaxAlgIncrement)}";
                break;
            case 3:
                type = $"*_{System.Math.Round (Random.Range (1.5f, GameVaarables.MaxGeoIncrement), 1)}";
                break;
            case 4:
                type = $"/_{System.Math.Round (Random.Range (1.5f, GameVaarables.MaxGeoIncrement), 1)}";
                break;
        }
    }
    public int GetCoinsCount (int currentCoins) {
        var coins = currentCoins;
        var t = type.Split ('_');
        switch (t[0])
        {
            case "+":
                coins += System.Convert.ToInt32 (t[1]);
                break;
            case "-":
                coins -= System.Convert.ToInt32 (t[1]);
                break;
            case "*":
                coins = Mathf.RoundToInt (coins * System.Convert.ToSingle (t[1]));
                break;
            case "/":
                coins = Mathf.RoundToInt (coins / System.Convert.ToSingle (t[1]));
                break;
        }

        return coins;
    }

    private void Start () {
        SetType ();
        PlatformSpawner = GameObject.FindWithTag ("Spawner");
        if (isEnd)
        {
            transform.eulerAngles = new Vector3 (0, 0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3 (0, 0, Random.Range (-maxRandomRotation, maxRandomRotation));
        }
        UIController.Instance.onButtonPressed += Rotate;
        GameControllers.Instance.OnGameEnded += GameOver;
    }
    private void OnDestroy () {
        GameControllers.Instance.OnGameEnded -= GameOver;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isEnd)
        {
            GameControllers.Instance.GameOver (true);
            return;
        }
        if (!collision.gameObject.CompareTag ("Player"))
            return;

        isTaked = true;
        transform.parent = null;
        if (GameVaarables.AddReachedPlatform ())
        {
            PlatformSpawner.GetComponent<PlatformSpavner> ().Spawn (true);
        }
        else
        {
            PlatformSpawner.GetComponent<PlatformSpavner> ().Spawn ();
        }
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