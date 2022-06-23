using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] float rpm;
    [SerializeField] private float horseSpeed;
    [SerializeField] private float turnSpeed = 45f;
    private float horizontal;
    private float vertical;
    private Rigidbody playerRb;
    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedoMeter;
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] List<WheelCollider> allWheels;
    private int wheelGround;
    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        //transform.Translate(Vector3.forward  * Time.deltaTime * speed * vertical);
        if (OnIsGround())
        {
            playerRb.AddRelativeForce(Vector3.forward * horseSpeed * vertical);

            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontal);

            speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 3.6f); // 3.6f for kpm
            speedoMeter.SetText("Speed : " + speed + "Kmp");

            rpm = Mathf.RoundToInt(speed % 30);
            rpmText.SetText("RMP : " + rpm);

        }    
    }

    bool OnIsGround()
    {
        wheelGround = 0;
        foreach(WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded) wheelGround++;
        }

        return wheelGround == 4 ? true : false;
    }

}
