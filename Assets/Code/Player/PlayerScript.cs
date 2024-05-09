using UnityEngine;
using Assets.Code.GeneralScripts;

namespace Assets.Code.Player
{
    public class PlayerScript : MonoBehaviour, IDead {

        [SerializeField] private PlayerConfig _config;
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
            Debug.Log("Игрок умер");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("wolf"))
        {
            Dead();
        }
    }
}