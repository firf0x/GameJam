using Assets.Code.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScreen : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Color color;
    [SerializeField] private Transform wolf;
    [SerializeField] private PlayerScript player;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        color = spriteRenderer.material.color;
        color.a = 0f;
        spriteRenderer.material.color = color;
    }

    IEnumerator FadeIn()
    {
        for (float a = 0.05f; a <= 1;  a +=0.05f) 
        {
            color.a = a;
            spriteRenderer.material.color = color;
            yield return new WaitForSeconds(0.05f);
        }
        player.Dead();
        wolf.position = new Vector3(0.3844f, -5.0565f, 0);
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        for (float a = 1f; a >= 0.05f; a -= 0.05f)
        {
            color.a = a;
            spriteRenderer.material.color = color;
            yield return new WaitForSeconds(0.05f);
        }
    }
    public void StartFadeIn()
    {
        StartCoroutine(FadeIn());
    }
}
