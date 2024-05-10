using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Resources.Config
{
    [CreateAssetMenu(fileName = "New KeyboardConfig", menuName = "Config/Settings/KeyboardConfig")]
    public class KeyboardConfig : ScriptableObject {
        [SerializeField] private KeyCode _sprint;
        [SerializeField] private KeyCode _menu;
    
        public KeyCode Sprint => this._sprint;
        public KeyCode Menu => this._menu;
    }
}