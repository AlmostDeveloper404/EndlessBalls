using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Zenject;
using System.Collections;
using System;

namespace Main
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text _levelText;
        [SerializeField] private TMP_Text _resultText;

        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _nextLevelButton;

        private LevelController _levelController;

        [SerializeField] private Animator _endLevelAnimator;


        [Inject]
        private void Construct(LevelController levelController)
        {
            _levelController = levelController;
        }
        private void OnEnable()
        {
            _restartButton.onClick.AddListener(_levelController.Restart);
            _nextLevelButton.onClick.AddListener(_levelController.LoadNext);

            GameManager.OnLevelCompleted += LevelCompleted;
            GameManager.OnLevelFailed += GameOver;
        }

        private void OnDisable()
        {
            _restartButton.onClick.RemoveAllListeners();
            _nextLevelButton.onClick.RemoveAllListeners();

            GameManager.OnLevelCompleted -= LevelCompleted;
            GameManager.OnLevelFailed -= GameOver;
        }

        private void Start()
        {
            _levelText.text = $"Level {PlayerResources.GetPlayerData.Level}";
        }

        private void LevelCompleted()
        {
            _resultText.text = "Level Completed!";
            _endLevelAnimator.SetTrigger(Animations.Finish);
        }

        private void GameOver()
        {
            _resultText.text = "Level Failed!";
            _nextLevelButton.gameObject.SetActive(false);
            _endLevelAnimator.SetTrigger(Animations.Finish);
        }
    }
}

