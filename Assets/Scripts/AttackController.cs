using System;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackController : MonoBehaviour
{
    [SerializeField] private UnityEvent onAttack;
    [SerializeField] private UnityEvent onDamaged;

    public void Attack(InputAction.CallbackContext context) {
        if (context.action.WasPerformedThisFrame()) {
            //Calcular ataques y daños
            onAttack?.Invoke();
        }
    }
    public void GetHit() {
        //Debug.Log("Ahh me hacen damages");
        onDamaged?.Invoke();
    }
}
