using UnityEngine;

public class CharacterSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] characters;

    void Awake() {
        StateController.playerLife = 3;
        Instantiate(characters[StateController.characterIndex], transform.position, Quaternion.identity);
    }
}
