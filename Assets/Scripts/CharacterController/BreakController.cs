using System;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.InputSystem;

public class BreakController : MonoBehaviour
{
    [SerializeField] private UnityEvent onBreak;
    private float timer = 0f;
    private Animator animator;

    void Start() {
        animator = GetComponent<Animator>();
    }

    void Update() {
        timer += Time.deltaTime;
        if (timer >= 10f) {
            if (animator.GetFloat("MovementSpeed") == 0) {
                Break();
            }
            timer = 0f;
        }
    }

    public void Break() {
        onBreak?.Invoke();
    }
}
