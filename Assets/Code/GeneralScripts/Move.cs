using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.GeneralScripts
{
    public class Move : IMovable, IGetValue{
        
        /// <summary>
        /// Класс для реализации движения
        /// </summary>

        // Event для передачи х-у объекту и считывание нажатий
        public event Action<Vector2> eventMove;

        // Переменная скорости объекта
        private float _value;

        // Конструктор класса
        public void Initialize(PlayerConfig settings)
        {
            this._value = settings.Speed;
        }

        // Функция передвижения
        public void OnWalk()
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");

            Vector2 vector = new Vector2(x, y).normalized;
            
            if (Input.GetKey(KeyCode.LeftShift))
            {
                Vector2 result = vector * _value * 2;
                eventMove?.Invoke(result);
            }
            else
            {
                Vector2 result = vector * _value;
                eventMove?.Invoke(result);
            }

        }

        // Получение переменной скорости
        public void GetValue(out float outValue) => outValue = this._value;
    }
}