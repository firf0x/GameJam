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
    bool isMove = false;

    private Vector3 originalPosition;
    private Vector3 targetPosition;

    void Start()
    {
        originalPosition = transform.position;
        targetPosition = originalPosition;
    }

    void FixedUpdate()
    {
        if (isMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, pl.gameObject.transform.position, Time.deltaTime * _speed * 4);
            Vector3 moveDirection2 = (pl.gameObject.transform.position - transform.position).normalized;
            float angle = Mathf.Atan2(moveDirection2.y, moveDirection2.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle - 180);
            if (Vector3.Distance(transform.position, pl.gameObject.transform.position) < 0.01f)
            {
                pl.AnimationActivate();
                isMove = false;
            }
        }
        else
        {
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
        if (other.CompareTag("bush"))
        {
            Debug.Log(3);
            isMove = false;
        }
        if (other.CompareTag("radar"))
        {
            Debug.Log(1);
            isMove = true;
        }
    }

}

