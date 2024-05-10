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

        private KeyCode _key;
        // Конструктор класса
        public Move(PlayerConfig settings, KeyboardConfig keyConfig)
        {
            this._firstValue = settings.Speed;
            this._secondValue = settings.Acceliration;
            this._key = keyConfig.Sprint;
        }

        // Функция передвижения
        public void OnWalk()
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");

            Vector2 vector = new Vector2(x, y).normalized;
            
            Vector2 result = vector * _firstValue;

            if (Input.GetKey(this._key))
            {
                result *= _secondValue;
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