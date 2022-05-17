using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    private void DefaultMove () {
        transform.Translate (new Vector3 (0, 0, -GameVaarables.PlatformMovingSpeed));
    }

    private void Update () {
        //DefaultMove ();
    }
}