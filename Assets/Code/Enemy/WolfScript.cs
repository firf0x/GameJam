using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Woolf : MonoBehaviour
{
    [SerializeField] private float move;
    [SerializeField] private float distance;
    [SerializeField] private float acceliration;
    [SerializeField] private GameObject player;
    private Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (player != null)
        {
            if ((player.transform.position.y - gameObject.transform.position.y) >= distance)
            {
                body.velocity = Vector2.up * move * acceliration;
            }
            else
            {
                body.velocity = Vector2.up * move;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            body.velocity = Vector2.zero;
        }
    }

}
