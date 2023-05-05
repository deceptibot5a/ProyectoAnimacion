using System;
using UnityEngine.Animations.Rigging;
using UnityEngine;

[Serializable] public struct MultiParentConstraintConfig {
    public MultiParentConstraint constraint;
    public int[] directParents;
    public int[] inverseParents;
}

[RequireComponent(typeof(Animator))]
public class AnimationDrivenParentConstraintController : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private MultiParentConstraintConfig[] drivenConstraints;
    [SerializeField] private string parameterName;

    private void Awake() {
        anim = GetComponent<Animator>();
    }

    private void Update() {
        float value = anim.GetFloat(parameterName);
        //Iterar por cada uno de los "archivos" de configuracion
        foreach (MultiParentConstraintConfig config in drivenConstraints) { 
            //Obtener todos los padres de cada constraint
            WeightedTransformArray array = config.constraint.data.sourceObjects;
            //Asignar los valores de peso directo basados en la curva
            for (int i = 0; i < config.directParents.Length; i++) {
                array.SetWeight(config.directParents[i], value);
            }
            //Asignar los valores de peso inverso basados en la curva
            for (int i = 0; i < config.inverseParents.Length; i++) {
                array.SetWeight(config.inverseParents[i], 1 - value);
            }

            config.constraint.data.sourceObjects = array;
        }
    }
}
