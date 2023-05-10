using System;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackController : MonoBehaviour
{
    [SerializeField] private UnityEvent onAttack;

    public void Attack(InputAction.CallbackContext context) {
        if (context.action.WasPerformedThisFrame()) {
            //Calcular ataques y daños
            onAttack?.Invoke();
        }
    }
}
