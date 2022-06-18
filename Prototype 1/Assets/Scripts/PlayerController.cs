using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 15f;
    [SerializeField] private float turnSpeed = 45f;
    private float horizontal;
    private float vertical;

    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward  * Time.deltaTime * speed * vertical);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontal);
    }
}
