using System;
using UnityEngine;
using UnityEngine.Animations.Rigging;

[RequireComponent(typeof(Animator))]
public class ConstraintAnimationCurveController : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private string curveName;
    [SerializeField] private MultiParentConstraint[] positiveConstraints;
    [SerializeField] private MultiParentConstraint[] invertedConstraints;

    private void Awake() {
        anim = GetComponent<Animator>();
    }

    void Update() {
        float value = anim.GetFloat(curveName);
        foreach (MultiParentConstraint positiveConstraint in positiveConstraints) {
            positiveConstraint.weight = value;
        }
        foreach (MultiParentConstraint multiParentConstraint in invertedConstraints) {
            multiParentConstraint.weight = 1 - value;
        }
    }
}
