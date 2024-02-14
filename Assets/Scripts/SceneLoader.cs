using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Linq;
using UnityEngine.Networking;
using TMPro;

namespace Main
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private PlayerData _defaultData;
        [SerializeField] private int _firstLevelToRepeat = 1;

        private void Start()
        {
            PlayerData playerData = SaveLoadProgress.LoadData<PlayerData>();
            if (playerData.Equals(default(PlayerData)))
            {
                playerData = _defaultData;
            }
            PlayerResources.SetupData(playerData);

            int allScenesCount = SceneManager.sceneCountInBuildSettings - 1;
            int startLevel = _firstLevelToRepeat - 1;
            int levelCount = allScenesCount - startLevel;
            int remainder;

            if (playerData.Level > allScenesCount)
            {
                remainder = (playerData.Level - startLevel - 1) % levelCount + startLevel + 1;
            }
            else
            {
                remainder = (playerData.Level - 1) % allScenesCount + 1;
            }

            SceneManager.LoadSceneAsync(remainder);

        }


        [ContextMenu("Delete Data")]
        private void DeleteData()
        {
            Debug.Log("Saves Deleted!");
            SaveLoadProgress.DeleteData();
        }
    }



}

