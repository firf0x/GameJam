using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Resources.Config;

namespace Assets.Code.GeneralScripts
{
    public class Move : IMovable, IGetValue{
        
        /// <summary>
        /// класс для реализации движения
        /// </summary>

        // Event для передачи х-у объекту и считывание нажатий
        public event Action<Vector2> eventMove;

        public event Action<float, float> eventInfo;
        // Переменная скорости объекта
        private float _firstValue;
        private float _secondValue;

        private Timer _timer;
        private KeyCode _key;
        private KeyCode _key2;
        // Конструктор класса
        public Move(PlayerConfig settings, KeyboardConfig keyConfig, TimerConfig timerConfig)
        {
            this._firstValue = settings.Speed;
            this._secondValue = settings.Acceliration;
            this._key = keyConfig.Sprint;
            this._key2 = keyConfig.Slowdown;
            _timer = new Timer(timerConfig);
        }

        // Функция передвижения
        public void OnWalk(bool isFirstLevel)
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");

            Vector2 vector = new Vector2(x, y).normalized;
            
            Vector2 result = vector * _firstValue;

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                Debug.Log("Произвести один раз");
            }
            else if (Input.GetKey(_key) && isFirstLevel)
            {
                if (_timer.GetTime())
                {
                    Debug.Log("Производится звук при беге");
                }
                result *= _secondValue;
                eventMove?.Invoke(result);
            }
            else if (Input.GetKey(this._key2) && !isFirstLevel)
            {
                result /= _secondValue;
                eventMove?.Invoke(result);
            }
            else if(vector.magnitude > 0)
            {
                if (_timer.GetTime())
                {
                    Debug.Log("Производится звук при ходьбе");
                }
                eventMove?.Invoke(result);
            }
            else
            {
                eventMove?.Invoke(result);
            }
        }

        // Функция передачи информации
        public void Info()
        {
            eventInfo?.Invoke(_firstValue, _secondValue);
        }

        // Получение переменной скорости
        public void GetValue(out float outValue) => outValue = this._firstValue;
    }
}