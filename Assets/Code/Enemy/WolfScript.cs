using Assets.Code.GeneralScripts;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using Assets.Resources.Config;
public class WolfScript : MonoBehaviour
{
    [SerializeField] private WolfConfig _config;
    [SerializeField] private Transform player;
    private Rigidbody2D body;

    public void Initialize()
    {
        body = gameObject.AddComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (player != null)
        {
            if ((player.position.y - gameObject.transform.position.y) >= _config.Distance)
            {
                Debug.Log(_config);
                Debug.Log(body);
                body.velocity = Vector2.up * _config.Move * _config.Acceliration;
            }
            else
            {
                body.velocity = Vector2.up * _config.Move;
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
