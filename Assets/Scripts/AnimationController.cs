using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour
{
    public void SetMotionValue(float value) {
        GetComponent<Animator>().SetFloat("MovementSpeed", value);
    }

    public void SetAttackTrigger() {
        GetComponent<Animator>().SetTrigger("Attack");
    }
    public void SetDamageTrigger() {
        GetComponent<Animator>().SetTrigger("Damage");
    }
}
