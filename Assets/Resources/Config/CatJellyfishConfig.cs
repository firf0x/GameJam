using UnityEngine;

namespace Assets.Resources.Config
{
    [CreateAssetMenu(fileName = "New CatJellyfishConfig", menuName = "Config/CatJellyfish/CatJellyfishConfig")]
    public class CatJellyfishConfig : ScriptableObject
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _radius;
        public float Speed => this._speed;
        public float Radius => this._radius;
    }
}