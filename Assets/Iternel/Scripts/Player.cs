using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rigitBody;
    [SerializeField] private GameObject MovingPlatforms;
    private void Start () {
        rigitBody = GetComponent<Rigidbody> ();
    }
    private void OnCollisionEnter (Collision collision) {
        StopAllCoroutines ();
        StartCoroutine (Jump (collision));
    }

    private IEnumerator Jump (Collision col) {
        var targetPlatform = MovingPlatforms.GetComponentsInChildren<Platform> ()[1];
        var time = 0f;
        var flyDuration = 1f;
        var startPos = transform.position;
        var finishPos1 = new Vector3 (0, GameVaarables.PlayerMaxJump, col.transform.position.z + GameVaarables.PlatformDelayRange / 2);
        var finishPos2 = targetPlatform.transform.position;

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