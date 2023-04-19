using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour
{
    public void SetMotionValue(float value) {
        GetComponent<Animator>().SetFloat("MovementSpeed", value);
    }
}
