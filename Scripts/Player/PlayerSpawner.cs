using UnityEngine;

namespace Player
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private GameObject[] characterPrefabs;

        private void Start()
        {
            string selectedCharacterName = PlayerPrefs.GetString("SelectedCharacterName", "");

            if (!string.IsNullOrEmpty(selectedCharacterName))
            {
                GameObject selectedPrefab = System.Array.Find(characterPrefabs, x => x.name == selectedCharacterName);

                if (selectedPrefab != null)
                {
                    Instantiate(selectedPrefab, spawnPoint.position, Quaternion.identity);
                }
                else
                {
                    Debug.LogError("Selected character prefab not found: " + selectedCharacterName);
                }
            }
            else
            {
                Debug.LogError("Selected character name is null or empty.");
            }
        }
    }
}