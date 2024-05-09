using UnityEngine;

public class PlayerScript : MonoBehaviour, IDead {
    
    private Move move;

    public void Initialize()
    {
        
        move.eventMove += Walk;
    }

    public void Walk(float value)
    {

    }

    public void Dead()
    {
        Debug.Log("Игрок умер");
    }
}