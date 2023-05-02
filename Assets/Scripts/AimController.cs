using UnityEngine;
using UnityEngine.Animations.Rigging;

public class AimController : MonoBehaviour
{
    [SerializeField] private Vector3 relativeDetectionPosition;
    [SerializeField] private float detectionRadius;
    [SerializeField] private LayerMask detectionMask;

    [SerializeField] private MultiAimConstraint aimConstraint;

    private void FixedUpdate() {
        Collider[] detected = Physics.OverlapSphere(transform.TransformPoint(relativeDetectionPosition), detectionRadius, detectionMask);
        
        if(detected != null && detected.Length > 0) {
            aimConstraint.weight = 1;
            aimConstraint.data.sourceObjects.Clear();
            aimConstraint.data.sourceObjects.Add(new WeightedTransform(detected[0].transform, 1));
        }
    }
}
