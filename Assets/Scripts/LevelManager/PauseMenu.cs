using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    void Start() {
        pauseMenu.SetActive(false);
    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (StateController.isPaused) ResumeGame();
            else PauseGame();
        }
    }
    public void PauseGame() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        StateController.isPaused = true;
    }
    public void ResumeGame() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        StateController.isPaused = false;
    }
    public void BacktoMain() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void QuitGame() {
        Application.Quit();
    }
}
