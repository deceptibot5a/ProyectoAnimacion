using System;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackController : MonoBehaviour
{
    [SerializeField] private UnityEvent onAttack;
    /*
    private SimpleMovement simpleMovement;
    private Animator animator;
    AnimatorStateInfo stateInfo;

    void Start() {
        animator = GetComponent<Animator>();
        simpleMovement = GetComponent<SimpleMovement>();
    }
    
    void Update() {
        stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("Attack1") || stateInfo.IsName("Attack2") || stateInfo.IsName("Attack3")) {
            simpleMovement.enabled = false;
        } else {
            simpleMovement.enabled = true;
        }
    }*/

    public void Attack(InputAction.CallbackContext context) {
        if (context.action.WasPerformedThisFrame()) {
            //Calcular ataques y daños
            onAttack?.Invoke();
        }
    }
}
