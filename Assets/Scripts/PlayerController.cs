using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI speedometerText;
    [SerializeField] private TextMeshProUGUI rpmText;
    [SerializeField] private float speed;
    [SerializeField] private float rpm;
    [SerializeField] List<WheelCollider> allWheels;
    private Rigidbody playerRb;
    [SerializeField] private float horsePower = 0;
    [SerializeField] private GameObject centerOfMass;
    private float turnSpeed = 45.0f;
    private float horizontalInput;
    private float forwardInput;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //get inputs
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        if (IsOnGround())
        {
            //move vehicle forwards
            //below transform.Translate(Vector3.forward) == transform.Translate(0, 0, 1);
            // transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
            playerRb.AddRelativeForce(Vector3.forward * forwardInput * horsePower);

            //turn vehicle
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
        }

        speed = Mathf.Round(playerRb.velocity.magnitude * 3.6f); //2.37f for mph
        speedometerText.SetText("Speed: " + speed + "kmph");

        rpm = Mathf.Round((speed % 30) * 40);
        rpmText.SetText("RPM: " + rpm);
    }

    private bool IsOnGround()
    {
        int wheelsOnGround = 0;

        foreach(WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }

        if(wheelsOnGround == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
