using UnityEngine;

public class CharacterSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] characters;

    void Awake() {
        Instantiate(characters[StateController.characterIndex], transform.position, Quaternion.identity);
    }
}
