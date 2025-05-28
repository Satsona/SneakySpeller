using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float rotationSpeed = 100f;

    private Rigidbody rb;
    private float moveInput;
    private float rotationInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Optional, handled manually
    }

    void Update()
    {
        // Only forward/backward movement
        moveInput = Input.GetAxisRaw("Vertical");

        // Only rotation (left/right)
        rotationInput = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        // Move forward/backward
        Vector3 moveDirection = transform.forward * moveInput * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + moveDirection);

        // Rotate left/right
        float rotation = rotationInput * rotationSpeed * Time.fixedDeltaTime;
        Quaternion turn = Quaternion.Euler(0f, rotation, 0f);
        rb.MoveRotation(rb.rotation * turn);
    }
}
