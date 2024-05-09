using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Config/Player/PlayerConfig")]
public class PlayerConfig : ScriptableObject {
    [SerializeField] private float _speed;
    public float Speed => this._speed;
}