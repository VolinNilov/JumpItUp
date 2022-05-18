using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private GameObject Player;
    [SerializeField] private Vector3 offset;

    private void Start () {
        Player = GameObject.FindWithTag ("Player");
    }

    void Update()
    {
        var x = Player.transform.position.x + offset.x;
        var y = transform.position.y;
        var z = Player.transform.position.z + offset.z;
        transform.position = new Vector3 (x, y, z);
    }
}