using UnityEngine;
using Assets.Code.GeneralScripts;
using System.Collections;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace Assets.Code.Player
{
    public class PlayerScript : MonoBehaviour, IDead {

        [SerializeField] private PlayerConfig _config;
        [SerializeField] private Vector2 spawnCoords;
        [SerializeField] private FadeScreen fade;
        [SerializeField] private GameObject player;

        private Move _move;


        private Rigidbody2D _rigidbody;


        public void Initialize()
        {
            _rigidbody = gameObject.AddComponent<Rigidbody2D>();
            _move = new Move();
            _move.Initialize(_config);
            _move.eventMove += Walk;

            _rigidbody.gravityScale = 0;
        }

        private void FixedUpdate() {
            _move.Walk();
        }

        public void Walk(Vector2 value)
        {
            _rigidbody.velocity = value;
        }

        public void Dead()
        {
            gameObject.transform.position = spawnCoords;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("wolf"))
            {
                fade.GetComponent<FadeScreen>().StartFadeIn(); // fade screen + dead
            }
        }
    }

}