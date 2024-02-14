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
        [SerializeField] private Button _speedUpButton;

        private LevelController _levelController;
        private SoundManager _soundManager;
        [SerializeField] private AudioClip _winSound;
        [SerializeField] private AudioClip _lostSound;

        [SerializeField] private Animator _endLevelAnimator;


        [Inject]
        private void Construct(LevelController levelController, SoundManager soundManager)
        {
            _levelController = levelController;
            _soundManager = soundManager;
        }
        private void OnEnable()
        {
            _restartButton.onClick.AddListener(_levelController.Restart);
            _nextLevelButton.onClick.AddListener(_levelController.LoadNext);
            _speedUpButton.onClick.AddListener(ToggleSpeed);

            GameManager.OnLevelCompleted += LevelCompleted;
            GameManager.OnLevelFailed += GameOver;
        }

        private void OnDisable()
        {
            _restartButton.onClick.RemoveAllListeners();
            _nextLevelButton.onClick.RemoveAllListeners();
            _speedUpButton.onClick.RemoveAllListeners();

            GameManager.OnLevelCompleted -= LevelCompleted;
            GameManager.OnLevelFailed -= GameOver;
        }

        private void Start()
        {
            _levelText.text = $"Level {PlayerResources.GetPlayerData.Level}";
        }

        private void LevelCompleted()
        {
            _soundManager.PlaySound(_winSound);
            _resultText.text = "Level Completed!";
            _endLevelAnimator.SetTrigger(Animations.Finish);
        }

        private void GameOver()
        {
            _soundManager.PlaySound(_lostSound);
            _resultText.text = "Level Failed!";
            _nextLevelButton.gameObject.SetActive(false);
            _endLevelAnimator.SetTrigger(Animations.Finish);
        }

        private void ToggleSpeed()
        {
            Time.timeScale = Time.timeScale == 1f ? 3f : 1f;
        }
    }
}

