using System;
using UnityEngine.Events;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    [SerializeField] private UnityEvent onDamage;

    public void Damage() {
        onDamage?.Invoke();
        StateController.playerLife--;
    }
}
