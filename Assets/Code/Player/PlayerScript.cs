using UnityEngine;
using Assets.Code.GeneralScripts;
using System.Collections;
using Assets.Resources.Config;
using static UnityEditor.Experimental.GraphView.GraphView;
using UnityEngine.UIElements;
using AK.Wwise;

namespace Assets.Code.Player
{
    public class PlayerScript : MonoBehaviour, IDead, IActivate {

        [SerializeField] private PlayerConfig _plConfig;
        [SerializeField] private KeyboardConfig _keyConfig;

        private Move _move;

        public AK.Wwise.Event footstepEvent;
      

        private Rotation _rotateScript;

        private Rigidbody2D _rigidbody;
        [SerializeField] public Animator anim;

        //------------------------------------------------------------------------

        public void Initialize()
        {
            _rigidbody = gameObject.AddComponent<Rigidbody2D>();
            _rigidbody.gravityScale = 0;

            _move = new Move(_plConfig, _keyConfig);
            _move.eventMove += OnWalk;
            _move.eventInfo += Info;

            _rotateScript = new Rotation();
            _rotateScript.eventRotate += OnRotate;

            _move.Info();
            _move.eventInfo -= Info;
        }
        
        //------------------------------------------------------------------------

        private void Update()
        {
            _rotateScript.OnRotate(gameObject.transform);
        }
        private void FixedUpdate() {
            _move.OnWalk();
        }

        //------------------------------------------------------------------------
        
        public void OnWalk(Vector2 value)
        {
            _rigidbody.velocity = value;
            
            if (value.magnitude > 0)
            {
                footstepEvent.Post(gameObject);
            }
            Debug.Log(footstepEvent);
        }
        public void OnRotate(float value)
        {
            gameObject.transform.rotation = Quaternion.Euler(0f, 0f, value - 90);
        }
        
        //------------------------------------------------------------------------
        
        public void ActivateObject(){
            _move.eventMove += OnWalk;
            _rotateScript.eventRotate += OnRotate;
        }

        public void DisactivateObject(){
            _move.eventMove -= OnWalk;
            _rotateScript.eventRotate -= OnRotate;
        }

        public void AnimationActivate(){
            anim.enabled = true;
        }

        public void AnimationDisactivate(){
            anim.enabled = false;
        }
        
        //------------------------------------------------------------------------
        
        public void Dead()
        {
            //DisactivateObject();
            gameObject.transform.position = _plConfig.spawnCoords;
        }


        private void Info(float first, float second)
        {
            Debug.Log($"Speed {first} : Acceliration {second}");
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("wolf"))
            {
                anim.enabled = true;
            }
        }
    }

}