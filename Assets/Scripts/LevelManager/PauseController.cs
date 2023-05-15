using System;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseController : MonoBehaviour
{
    [SerializeField] private UnityEvent onPause;
    PauseMenu pauseMenu;

    void Start() {
        pauseMenu = GameObject.FindObjectOfType<PauseMenu>();
    }
    public void PauseKey(InputAction.CallbackContext context) {
        if (context.action.WasPerformedThisFrame()) {
            onPause?.Invoke();
            if (StateController.isPaused) pauseMenu.ResumeGame();
            else pauseMenu.PauseGame();
        }
    }
}
