using System;
using UnityEngine;

namespace Assets.Code.GeneralScripts
{
    public class Rotation : IRotate {

        /// <summary>
        /// Класс для подтверждения поворота
        /// </summary>

        // Event для передачи float
        public event Action<float> eventRotate;
        
        // Функция реализующая просцёт поворота
        public void OnRotate(Transform _object) {
            Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - _object.position;
            float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
            
            eventRotate?.Invoke(rotateZ);
        }
    }
}