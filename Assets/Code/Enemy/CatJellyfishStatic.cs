using Assets.Code.Player;
using Assets.Resources.Config;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class CatJellyfisSattic : MonoBehaviour
{
    //[SerializeField] private CatJellyfishConfig _config;
    [SerializeField] private PlayerScript pl;
    public bool isMove = false;
    public bool isDead = false;
    private Animator anim;

    public Vector3 originalPosition;
    private Vector3 targetPosition;

    void Start()
    {
        originalPosition = transform.position;
        targetPosition = originalPosition;
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (pl.invize)
        {
            isMove = false;
        }

        if (isMove && !pl.invize)
        {
            Debug.Log(12345);
            transform.position = Vector3.MoveTowards(transform.position, pl.gameObject.transform.position, Time.deltaTime * 2 * 2);
            Vector3 moveDirection2 = (pl.gameObject.transform.position - transform.position).normalized;
            float angle = Mathf.Atan2(moveDirection2.y, moveDirection2.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle - 180);
            if (Vector3.Distance(transform.position, pl.gameObject.transform.position) < 1f)
            {
                //anim.SetBool("IsEx", true);
                anim.Play("explosionsmall");
                pl.AnimationActivate();
                isMove = false;
                isDead = true;
            }
        }
        else if (!isDead)
        {
            transform.position = Vector3.MoveTowards(transform.position, originalPosition, Time.deltaTime * 2 * 2);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("radar"))
        {
            Debug.Log(1);
            isMove = true;
        }
    }

}

