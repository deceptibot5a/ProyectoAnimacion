using System;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.InputSystem;

public class DeathController : MonoBehaviour
{
    [SerializeField] private UnityEvent onDeath;
    [SerializeField] private SimpleMovement simpleMovement;

    public void Death(InputAction.CallbackContext context) {
        if (context.action.WasPerformedThisFrame()) {
            onDeath?.Invoke();
            simpleMovement.enabled = false;
        }
    }
}
