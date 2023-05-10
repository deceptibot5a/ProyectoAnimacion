using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

interface IDamageable
{
    void ReactToDamage();
    int Faction { get; }
    int[] EnemyFactions { get; }
}
public class DamageController : MonoBehaviour, IDamageable
{
    [SerializeField] private UnityEvent onDamaged;
    [SerializeField] private int faction;
    [SerializeField] private int[] enemyFactions;

    private void OnTriggerEnter(Collider other) {
        if (other.GetComponent<IDamageable>() != null) {
            IDamageable dmg = other.GetComponent<IDamageable>();
            if (dmg!= null) { 
                if(dmg.EnemyFactions.Contains(this.Faction)) { 
                    ReactToDamage();
                }
            }
        }
    }

    public void ReactToDamage() {
        onDamaged?.Invoke();
    }

    public int Faction => faction;
    public int[] EnemyFactions => enemyFactions;
}
