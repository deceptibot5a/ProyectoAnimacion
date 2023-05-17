using System;
using UnityEngine.Events;
using UnityEngine;

public class DeathController : MonoBehaviour
{
    [SerializeField] private UnityEvent onDeath;
    [SerializeField] private SimpleMovement simpleMovement;

    void Update() {
        if (StateController.playerLife <= 0) Death();
    }
    public void Death() {
        onDeath?.Invoke();
        simpleMovement.enabled = false;
        Invoke("YouDied", 3f);
    }
    private void YouDied() {
        StateController.isDead = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
