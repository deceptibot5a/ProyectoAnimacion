using UnityEngine;

public class CharacterSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] characters;

    void Awake() {
        StateController.playerLife = 100f;
        Instantiate(characters[StateController.characterIndex], transform.position, Quaternion.identity);
    }
}
