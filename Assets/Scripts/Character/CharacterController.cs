using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Demo.Character
{
    public class CharacterController : MonoBehaviour
    {
        [SerializeField] private CharacterControllerSettings _characterControllerSettings;

        [SerializeField] private Rigidbody _rigidBody;

        public Vector3 playerDirection;
        public Vector3 playerLeftDirection;
        public Vector3 playerRightDirection;



        public int positionLocalX;

        private void Awake()
        {
            positionLocalX = 0;
            playerDirection = new Vector3(0, 0, -1);
            playerLeftDirection = new Vector3(1, 0, 0);
            playerRightDirection = new Vector3(-1, 0, 0);
        }

        void FixedUpdate()
        {
            MoveStraight();
        }


        public void LeftCheckPointControl()
        {
            positionLocalX = 0; 
            playerDirection = new Vector3(1, 0, 0);
            playerLeftDirection = new Vector3(0, 0, 1);
            playerRightDirection = new Vector3(0, 0, -1);


        }

        private void OnTriggerEnter(Collider coll)
        {
            if (coll.CompareTag("LeftCheckPoint"))
            {
                LeftCheckPointControl();
            }
        }

        public void MoveStraight()
        {
            _rigidBody.MovePosition(transform.position + playerDirection * _characterControllerSettings.StraightSpeed * Time.deltaTime);
        }


        public void MoveLeft()
        {
            if (positionLocalX > -3)
            {
                Debug.Log("k");
                transform.Translate(playerLeftDirection * _characterControllerSettings.LeftRightSpeed);
                positionLocalX--;
            }
        }

        public void MoveRight()
        {
            if (positionLocalX < 3)
            {
                Debug.Log("kk");
                transform.Translate(playerRightDirection * _characterControllerSettings.LeftRightSpeed);
                positionLocalX++;
            }
        }
    }
}
