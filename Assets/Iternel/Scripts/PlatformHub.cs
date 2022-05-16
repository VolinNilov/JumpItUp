using UnityEngine;
using System;

public class PlatformHub : MonoBehaviour
{
    [SerializeField] private GameObject PlatformPrefab;

    public void Move(int rotation)
    {
        // �������� �� � � GameVaarables.RotationSpeed - ����� �������� ��������
        transform.Rotate(new Vector3(0, 0, rotation * GameVaarables.RotationSpeed));
    }
}