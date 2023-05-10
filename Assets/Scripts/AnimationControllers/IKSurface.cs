using UnityEngine;
using System.Linq;

public class IKSurface : MonoBehaviour
{
    const float REFRESH_DELAY = 0.5f;
    [SerializeField] private float detectionRadius;
    [SerializeField] private LayerMask detectionMask;
    [SerializeField] private Transform referencePoint;
    [SerializeField] private Transform raycastReference;

    // 1) Encontrar objetos idoneos

    /// <summary>
    /// Decides whether or not a surface is suitable for IK snap
    /// </summary>
    private Collider[] Query() {
        return Physics.OverlapSphere(referencePoint.position, detectionRadius, detectionMask);
    }

    // 2) Encontrar el objeto cuyo punto mas cercano al punto de referencia es el mas cercano
    private bool GetNearestPositionForSnap(Collider[] nearColliders, out Vector3 nearestPoint) {
        try {
            //Encontrar punto mas cercano de la superficie
            //Creo una lista de los puntos mas cercanos a cada uno de los colliders
            var closestPoints = nearColliders.Select(collider => collider.ClosestPoint(referencePoint.position));

            //Encuentro el punto mas cercano perteneciente al collider mas cercano
            Vector3 closestPoint = closestPoints
                .OrderBy(position => Vector3.Distance(referencePoint.position, position))
                .First();
            //Evaluo si el punto de referencia esta dentro del collider
            if (closestPoint == referencePoint.position) {
                //Estoy dentro
                //Debo castear el rayo desde la mano hacia el punto de referencia
                Ray ray = new Ray(raycastReference.position, referencePoint.position - raycastReference.position);
                if (Physics.Raycast(ray, out RaycastHit hit, ray.direction.magnitude, detectionMask)) {
                    //Devolvemos el punto de interseccion
                    nearestPoint = hit.point;
                    return true;
                }
            } else {
                //Estoy fuera
                nearestPoint = closestPoint;
                return true;
            }
        } catch {
            //Ignore
        }
        //Si no se detecta nada, retornamos la posision misma de la mano
        nearestPoint = transform.position;
        return false;
    }

    private void LateUpdate() {
        
        if (GetNearestPositionForSnap(Query(), out Vector3 nearestPosition)) {
            //Fuperficie con posicion cercana valida detectada
            transform.position = nearestPosition;
            //Mandar la señal
            gameObject.SendMessage("OverrideIK", true, SendMessageOptions.DontRequireReceiver);
        } else {
            gameObject.SendMessage("OverrideIK", false, SendMessageOptions.DontRequireReceiver);
        }
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(referencePoint.position, detectionRadius);
    }
}
