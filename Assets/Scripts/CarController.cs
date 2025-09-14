using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed = 40f;
    public float brakeForce = 15f;
    public float turnSpeed = 500f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float turnInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKey(KeyCode.JoystickButton0)) // Accelerate
        {
            rb.AddForce(transform.forward * speed);
        }

        if (Input.GetKey(KeyCode.JoystickButton1)) // Brake
        {
            // Use the new linearVelocity property here
            rb.AddForce(-rb.linearVelocity.normalized * brakeForce);
        }

        rb.AddTorque(transform.up * turnInput * turnSpeed);
    }
}