using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    public void CharacterSelect(int value) {
        SceneManager.LoadScene(1);
        StateController.characterIndex = value;
    }
}
