using UnityEngine;

[CreateAssetMenu(fileName = "WolfConfig", menuName = "Config/Wolf/WolfConfig")]
public class WolfConfig : ScriptableObject
{
    [SerializeField] private float _move;
    [SerializeField] private float _distance;
    [SerializeField] private float _acceliration;
    public float Move => this._move;
    public float Distance => this._distance;
    public float Acceliration => this._acceliration;
}