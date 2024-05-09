using UnityEngine;
using Assets.Code.Player;

namespace Assets.Code.Other
{
    public class ManagerInitialize : MonoBehaviour {
        
        /// <summary>
        /// Класс инициализатор
        /// Инициализирует объекты на сцене
        /// </summary>

        // Класс игрока
        [SerializeField] private PlayerScript _player;

        // Методы юнити
        private void Awake() {
            // Инициализация игрока
            _player.Initialize();
        }

    }
}