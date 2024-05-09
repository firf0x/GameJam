using UnityEngine;
using Assets.Code.GeneralScripts;
using System.Collections;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace Assets.Code.Player
{
    public class PlayerScript : MonoBehaviour, IDead {

        /// <summary>
        /// Основной класс игрока реализующий:
        /// 1. Передвижение
        /// 2. Вращение
        /// </summary> 


        //-------------------------------------------------------------------------------
        // Конфиг игрока
        [SerializeField] private PlayerConfig _config;


        //-------------------------------------------------------------------------------
        // Классы для доп. функций
        private Move _moveScript;

        private Rotate _rotateScript;

        //-------------------------------------------------------------------------------
        // Компоненты юнити
        private Rigidbody2D _rigidbody;



        //-------------------------------------------------------------------------------
        // Инициализация класса
        public void Initialize() {
            _rigidbody = gameObject.AddComponent<Rigidbody2D>();
            _rigidbody.gravityScale = 0;

            _moveScript = new Move();
            _moveScript.Initialize(_config);
            _moveScript.eventMove += OnWalk;

            _rotateScript = new Rotate();
            _rotateScript.eventRotate += OnRotate;
        }
        
        
        //-------------------------------------------------------------------------------
        // Методы MonoBehaviour
        private void Update() {
            // Запрос на реализацию поворота
            _rotateScript.OnRotate(Input.mousePosition.x);
        }
        
        private void FixedUpdate() {
            // Запрос на реализацию передвижения
            _moveScript.OnWalk();
        }

        //-------------------------------------------------------------------------------
        // Реализация перемещения
        public void OnWalk(Vector2 value) {
            _rigidbody.velocity = value;
        }


        //-------------------------------------------------------------------------------
        // Реализация поворота
        public void OnRotate(bool isActive) {
            gameObject.GetComponent<SpriteRenderer>().flipX = isActive;
        }


        //-------------------------------------------------------------------------------
        // Реализация смерти
        public void Dead() {
            Debug.Log("Игрок умер");
        }
    }
}