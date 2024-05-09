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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("wolf"))
        {
            Dead();
        }
    }
}