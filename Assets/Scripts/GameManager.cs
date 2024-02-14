using System;
using UnityEngine;

namespace Main
{
    public enum GameState { Preporations, StartGame,LevelCompleted, LevelFailed}


    public static class GameManager
    {
        public static event Action OnPreporationsStarted;
        public static event Action OnGameStarted;
        public static event Action OnLevelFailed;
        public static event Action OnLevelCompleted;


        public static void ChangeGameState(GameState gameState)
        {
            switch (gameState)
            {
                case GameState.Preporations:
                    OnPreporationsStarted?.Invoke();
                    break;
                case GameState.StartGame:
                    OnGameStarted?.Invoke();
                    break;
                case GameState.LevelFailed:
                    OnLevelFailed?.Invoke();
                    break;
                case GameState.LevelCompleted:
                    OnLevelCompleted?.Invoke();
                    break;
                default:
                    break;
            }
        }
    }
}

