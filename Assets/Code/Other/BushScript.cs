using Assets.Code.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BushScript : MonoBehaviour
{
    [SerializeField] private PlayerScript pl;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //При вхождение в кусты, кусты становятся полупрозрачными
            pl.invize = true;
            pl._radar.CahgeRadius("invisible");
            gameObject.GetComponent<Tilemap>().color = new Vector4(gameObject.GetComponent<Tilemap>().color.a, gameObject.GetComponent<Tilemap>().color.g, gameObject.GetComponent<Tilemap>().color.b, 0.5f);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            pl.invize = false;
            pl._radar.gameObject.SetActive(true);
            gameObject.GetComponent<Tilemap>().color = new Vector4(gameObject.GetComponent<Tilemap>().color.a, gameObject.GetComponent<Tilemap>().color.g, gameObject.GetComponent<Tilemap>().color.b, 1f);
        }
    }
}
