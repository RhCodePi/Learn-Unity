using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private GameObject player;
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
