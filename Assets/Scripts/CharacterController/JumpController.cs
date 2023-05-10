using System;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.InputSystem;

public class JumpController : MonoBehaviour
{
    [SerializeField] private UnityEvent onJump;
    [SerializeField] private Rigidbody rb;

    private float jumpForce = 4.5f;

    public void Jump(InputAction.CallbackContext context) {
        if (context.action.WasPerformedThisFrame()) {
            onJump?.Invoke();
            Invoke("JumpForce", 0.5f);
        }
    }
    private void JumpForce() {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
