using Assets.Code.Player;
using Assets.Resources.Config;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class CatJellyfish : MonoBehaviour
{
    //[SerializeField] private CatJellyfishConfig _config;
    [SerializeField] private Transform circleCenter;
    [SerializeField] private float _speed;
    [SerializeField] private float _radius;
    [SerializeField] private PlayerScript pl;
    private Animator anim;
    public bool isMove = false;
    public bool isDead = false;

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
            transform.position = Vector3.MoveTowards(transform.position, pl.gameObject.transform.position, Time.deltaTime * _speed * 2);
            Vector3 moveDirection2 = (pl.gameObject.transform.position - transform.position).normalized;
            float angle = Mathf.Atan2(moveDirection2.y, moveDirection2.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle - 180);
            if (Vector3.Distance(transform.position, pl.gameObject.transform.position) < 1f)
            {
                anim.SetBool("isEx", true);
                transform.position = originalPosition;
                pl.AnimationActivate();
                isMove = false;
                isDead = true;
            }
        }
        else if (!isDead)
        {
            Debug.Log(targetPosition);
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                // ѕолучаем рандомно точку, в сторону которой будет двигатьс€ медузка
                targetPosition = GetRandomPositionInsideCircle();
            }

            Vector3 moveDirection = (targetPosition - transform.position).normalized;

            if (moveDirection != Vector3.zero)
            {
                // ѕоворачиваем медузу в сторону движени€
                float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0f, 0f, angle - 180);
            }
            // ƒвигаем медузу к цели
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * _speed);
        }
    }

    Vector3 GetRandomPositionInsideCircle()
    {
        float angle = Random.Range(0f, Mathf.PI * 2f);
        float radius = Random.Range(0f, _radius);

        // ¬ычисл€ем случайную позицию внутри круга
        Vector3 randomPosition = circleCenter.position + new Vector3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius, 0f);

        return randomPosition;
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

