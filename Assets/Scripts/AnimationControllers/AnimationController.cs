using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour {
    public void SetMotionValue(float value) {
        GetComponent<Animator>().SetFloat("MovementSpeed", value);
    }
    public void SetAttackTrigger() {
        GetComponent<Animator>().SetTrigger("Attack");
    }
    public void SetDamageTrigger() {
        GetComponent<Animator>().SetTrigger("Damage");
    }
    public void SetJumpTrigger() {
        GetComponent<Animator>().SetTrigger("Jump");
    }
    public void SetDeathTrigger() {
        GetComponent<Animator>().SetTrigger("Death");
    }
    public void SetBreakTrigger() {
        GetComponent<Animator>().SetTrigger("Break");
    }
}
