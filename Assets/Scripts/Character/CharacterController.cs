using Demo.PlayerInput;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Demo.Character
{
    public class CharacterController : MonoBehaviour
    {
        [SerializeField] private CharacterControllerSettings _characterControllerSettings;
        [SerializeField] private InputData _inputData;
        [SerializeField] private Rigidbody _rigidBody;

        public Vector3 playerDirection;
        public Vector3 playerLeftDirection;
        public Vector3 playerRightDirection;

        public bool moving;


        public int positionLocalX;

        private void Awake()
        {
            moving = false;
            positionLocalX = 0;
            playerDirection = new Vector3(0, 0, -1);
            playerLeftDirection = new Vector3(1, 0, 0);
            playerRightDirection = new Vector3(-1, 0, 0);
        }

        void FixedUpdate()
        {
            MoveStraight();
            CheckInput();
        }


        public void LeftCheckPointControl()
        {
            positionLocalX = 0; 
            playerDirection = new Vector3(1, 0, 0);
            playerLeftDirection = new Vector3(0, 0, 1);
            playerRightDirection = new Vector3(0, 0, -1);
            transform.rotation = Quaternion.Euler(0, -90, 0);

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
            transform.position = Vector3.Lerp(transform.position, transform.position + playerDirection, _characterControllerSettings.StraightSpeed * Time.deltaTime);
            //_rigidBody.MovePosition(transform.position + playerDirection * _characterControllerSettings.StraightSpeed * Time.deltaTime);
        }

        public void CheckInput()
        {
            Vector3 firstPressPos = _inputData.StartClickPosition;
            Vector3 lastPressPos = _inputData.LastClickPosition;
            Vector3 currentPressPos = _inputData.CurrentClickPosition;


            Vector2 currentSwipe = new Vector3(currentPressPos.x - firstPressPos.x, currentPressPos.y - firstPressPos.y, currentPressPos.z - firstPressPos.z);

            //normalize the 2d vector
            currentSwipe.Normalize();

            //swipe left
            if (currentSwipe.x < 0 && currentSwipe.y > -0.4f && currentSwipe.y < 0.4f)
            {
                MoveLeft();
                //Debug.Log("Left swipe");
                _inputData.StartClickPosition = _inputData.CurrentClickPosition;

            }
            //swipe right
            if (currentSwipe.x > 0 && currentSwipe.y > -0.4f && currentSwipe.y < 0.4f)
            {
                MoveRight();
                Debug.Log("right swipe");
                _inputData.StartClickPosition = _inputData.CurrentClickPosition;
            }
            

        }

        public void MoveLeft()
        {
            //Sonradan yaptim
            if (!moving && positionLocalX > -2)
            {
                Debug.Log("girdi");
                
                transform.DOMove(transform.position + (playerLeftDirection * 2) + (playerDirection * 2), 0.50f).OnUpdate(delegate
                {
                    moving = true;
                })
                .OnComplete(delegate
                {
                    positionLocalX--;
                    moving = false;
                });
            }

            //ilk commitledigim
            //transform.position = Vector3.Lerp(transform.position, transform.position + playerLeftDirection, _characterControllerSettings.LeftRightSpeed * Time.deltaTime);
        }

        public void MoveRight()
        {

            //Sonradan yaptim
            if (!moving && positionLocalX < 2)
            {
                Debug.Log("sagGirdi");
                transform.DOMove(transform.position + (playerRightDirection * 2) + (playerDirection * 2), 0.50f).OnUpdate(delegate
                {
                    moving = true;
                })
                .OnComplete(delegate
                {
                    positionLocalX++;
                    moving = false;
                });
            }

            //ilk commitledigim
            //transform.position = Vector3.Lerp(transform.position, transform.position + playerRightDirection, _characterControllerSettings.LeftRightSpeed * Time.deltaTime);
        }
    }
}
