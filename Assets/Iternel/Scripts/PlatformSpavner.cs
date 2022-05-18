using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpavner : MonoBehaviour
{
    [SerializeField] private Transform MovingPlatforms;
    [SerializeField] private GameObject PlatformPrefab;

    private GameObject Player;
    private int PlatformCount;

    void Start()
    {
        PlatformCount = 3;
        Player = GameObject.FindWithTag("Player");
    }

    public void Spawn()
    {
        var obj = Instantiate(PlatformPrefab,
            new Vector3(0, 0, PlatformCount * GameVaarables.PlatformDelayRange),
            Quaternion.identity,
            MovingPlatforms);

        PlatformCount++;
    }

    void Update()
    {

    }
}