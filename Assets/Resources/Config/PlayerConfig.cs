using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Config/Player/PlayerConfig")]
public class PlayerConfig : ScriptableObject {
    [SerializeField] private float _speed;
    [SerializeField] private Vector2 _spawnCoords;
    public float Speed => this._speed;
    public Vector2 spawnCoords => this._spawnCoords;
}