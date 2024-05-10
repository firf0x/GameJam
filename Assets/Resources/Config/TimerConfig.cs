using UnityEngine;

[CreateAssetMenu(fileName = "New TimerConfig", menuName = "Config/Settings/TimerConfig")]
public class TimerConfig : ScriptableObject {
    
    [SerializeField] private float _coolDown;


    public float CollDown => _coolDown;
}