using UnityEngine;
using Assets.Code.Player;
using Unity.VisualScripting;

namespace Assets.Code.Other
{
    public class ManagerInitialize : MonoBehaviour {
        
        /// <summary>
        /// Класс инициализатор
        /// Инициализирует объекты на сцене
        /// </summary>

        // Класс игрока
        [SerializeField] private PlayerScript _player;
        
        [SerializeField] private WolfScript _wolfs;

        // Методы юнити
        private void Awake() {
            // Инициализация игрока
            _player.Initialize();
            if (_player.firstLevel)
                _wolfs.Initialize();
        }

    }
}