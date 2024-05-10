using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Resources.Config
{
    [CreateAssetMenu(fileName = "New PlayerConfig", menuName = "Config/Player/PlayerConfig")]
    public class PlayerConfig : ScriptableObject {
        [SerializeField] private float _speed;
        [SerializeField] private float _acceliration;
        [SerializeField] private Vector2 _spawnCoords;
        public float Speed => this._speed;
        public float Acceliration => this._acceliration;
        public Vector2 spawnCoords => this._spawnCoords;
    }
}