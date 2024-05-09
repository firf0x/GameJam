using UnityEngine;
using Assets.Code.GeneralScripts;
using System.Collections;
using static UnityEditor.Experimental.GraphView.GraphView;
using UnityEngine.UIElements;

namespace Assets.Code.Player
{
    public class PlayerScript : MonoBehaviour, IDead {

        [SerializeField] private PlayerConfig _config;
        [SerializeField] public Animator anim;

        private Move _move;

        private Rotation _rotateScript;

        private Rigidbody2D _rigidbody;


        public void Initialize()
        {
            _rigidbody = gameObject.AddComponent<Rigidbody2D>();
            _move = new Move();
            _move.Initialize(_config);
            _move.eventMove += OnWalk;

            _rotateScript = new Rotation();
            _rotateScript.eventRotate += OnRotate;

            _rigidbody.gravityScale = 0;
        }
        private void Update()
        {
            // Запрос на реализацию поворота
            _rotateScript.OnRotate(Input.mousePosition.x);
        }
        private void FixedUpdate() {
            _move.OnWalk();
        }

        public void OnWalk(Vector2 value)
        {
            _rigidbody.velocity = value;
        }
        public void OnRotate(bool isActive)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = isActive;
        }
        public void Dead()
        {
            gameObject.transform.position = _config.spawnCoords;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("wolf"))
            {
                anim.enabled = true;
            }
        }
    }

}