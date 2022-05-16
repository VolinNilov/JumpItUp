using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpavner : MonoBehaviour
{
    [SerializeField] private Transform MovingPlatforms;
    [SerializeField] private GameObject PlatformPrefab;

    private GameObject Player;
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    public void Spawn()
    {
        Instantiate(PlatformPrefab, new Vector3(0, 0, 0), Quaternion.identity, MovingPlatforms);
    }

    void Update()
    {

    }
}