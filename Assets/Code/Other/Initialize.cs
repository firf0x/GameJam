using UnityEngine;
using Assets.Code.Player;
public class Initialize : MonoBehaviour {
    
    [SerializeField] private PlayerScript _player;

    private void Awake() {
        _player.Initialize();
    }

}