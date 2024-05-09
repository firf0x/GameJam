using UnityEngine;
using Assets.Code.Player;
public class Initialize : MonoBehaviour {
    
    [SerializeField] private PlayerScript _player;
    [SerializeField] private WolfScript _wolfs;

    private void Awake() {
        _player.Initialize();
        _wolfs.Initialize();
    }

}