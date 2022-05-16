using System.Collections;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private GameObject PlatformSpawner;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
            return;

        PlatformDeleter();
    }
    private IEnumerator PlatformDeleter()
    {
        PlatformSpawner.GetComponent<PlatformSpavner>().Spawn();
        yield return new WaitForSeconds(GameVaarables.DeletingTime);
        Destroy(this.gameObject);
    }
}