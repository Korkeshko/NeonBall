using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Controls controls;
    private Vector2 moveInput;
    private Rigidbody rb;
    [SerializeField] private float moveSpeed = 5f;
    // private float inertia = 0.1f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        
        controls = new Controls();
        controls.Player.Movement.performed += OnMove;
        controls.Player.Movement.canceled += OnMove;
    }

    private void OnEnable()
    {
        controls.Enable();
        StartCoroutine(MovePlayer());
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private IEnumerator MovePlayer()
    {
        while (true)
        {
            Vector3 move = new Vector3(moveInput.x, 0, moveInput.y) * moveSpeed * Time.deltaTime;

            if (moveInput != Vector2.zero)
            {
                rb.AddForce(move, ForceMode.Acceleration);
                //rb.MovePosition(transform.position + move);
            }
            // else
            // {
            //     rb.velocity = new Vector3(rb.velocity.x * (1 - inertia), rb.velocity.y, rb.velocity.z * (1 - inertia));
            // }
            //rb.rotation = Quaternion.identity;
            

            yield return new WaitForFixedUpdate();
        }
    }
}
