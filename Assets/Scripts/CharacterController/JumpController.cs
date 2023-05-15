using System;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.InputSystem;

public class JumpController : MonoBehaviour
{
    [SerializeField] private UnityEvent onJump;
    [SerializeField] private Rigidbody rb;

    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpDelay;

    public void Jump(InputAction.CallbackContext context) {
        if (context.action.WasPerformedThisFrame()) {
            onJump?.Invoke();
            Invoke("JumpForce", jumpDelay);
        }
    }
    private void JumpForce() {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
