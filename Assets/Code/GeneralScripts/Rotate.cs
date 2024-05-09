using System;
using UnityEngine;

namespace Assets.Code.GeneralScripts
{
    public class Rotate : IRotate {

        /// <summary>
        /// Класс для подтверждения поворота
        /// </summary>

        // Event для передачи bool
        public event Action<bool> eventRotate;
        
        // Функция реализующая проверку на подтверждение
        public void OnRotate(float cursorPointX) {
            if(cursorPointX !< Screen.width / 2)
                eventRotate?.Invoke(true);
            else
                eventRotate?.Invoke(false);
        }
    }
}