using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject[] menuItems;

    public void PlayGame() {
        MenuChanger(1);
        //CharacterSelection();
        //SceneManager.LoadScene();
    } 
    public void Credits() {
        MenuChanger(2);
    }
    public void QuitGame() {
        Application.Quit();
    }
    public void GoBack() {
        MenuChanger(0);
    }

    //private void CharacterSelection() { }

    private void MenuChanger(int menuIndex) {
        for (int i = 0; i < menuItems.Length; i++) {
            if (i != menuIndex) menuItems[i].SetActive(false);
            else menuItems[i].SetActive(true);
        }
    }
}
