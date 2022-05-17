using System.Collections;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private GameObject PlatformSpawner;
    private GameObject UsedPlatforms;

    private void Start () {
        PlatformSpawner = GameObject.FindWithTag ("Spawner");
        UsedPlatforms = GameObject.FindWithTag ("Used");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
            return;

        transform.parent = UsedPlatforms.transform;
        PlatformSpawner.GetComponent<PlatformSpavner> ().Spawn ();
        StartCoroutine (PlatformDeleter ());
    }
    private IEnumerator PlatformDeleter()
    {
        yield return new WaitForSeconds(GameVaarables.DeletingTime);
        Destroy(this.gameObject);
    }
}