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

    private Animator animator;
    AnimatorStateInfo stateInfo;

    void Start() {
        animator = GetComponent<Animator>();
    }

    public void Jump(InputAction.CallbackContext context) {
        if (context.action.WasPerformedThisFrame()) {
            stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.IsName("Motion")) {
                onJump?.Invoke();
                Invoke("JumpForce", jumpDelay);
            }
        }
    }
    private void JumpForce() {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
