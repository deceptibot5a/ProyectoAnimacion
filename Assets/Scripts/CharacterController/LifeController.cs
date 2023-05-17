using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;

public class LifeController : MonoBehaviour
{
    [SerializeField] private UnityEvent onDamage;
    private float damageValue = 15f;
    Slider slider;

    void Start() {
        slider = FindObjectOfType<Slider>();
        Debug.Log("vida: " + StateController.playerLife);
    }
    public void Damage() {
        onDamage?.Invoke();
        StateController.playerLife -= damageValue;
        Debug.Log("vida: " + StateController.playerLife);
        slider.value -= damageValue/100f;
    }
}
