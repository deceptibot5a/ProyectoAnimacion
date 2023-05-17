using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    [SerializeField] private GameObject deathMenu;

    void Start() {
        deathMenu.SetActive(false);
    }
    void Update() {
        if (StateController.isDead == true) {
            deathMenu.SetActive(true);
            StateController.isDead = false;
        }
    }
    public void Retry() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        StateController.isDead = false;
        SceneManager.LoadScene(1);
    }
    public void BacktoMain() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene(0);
    }
    public void QuitGame() {
        Application.Quit();
    }
}
