using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Demo.PlayerInput
{
    [CreateAssetMenu(menuName = "Demo/Input/Input Data")]
    public class InputData : ScriptableObject
    {
        public Vector3 StartClickPosition;
        public Vector3 CurrentClickPosition;
        public Vector3 LastClickPosition;



        public void ProcessInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var mousePos = Input.mousePosition;
                //mousePos.z = 10;
                Debug.Log(Input.mousePosition);
                //Debug.Log(Camera.main.ScreenToWorldPoint(mousePos));
                //StartClickPosition = Camera.main.ScreenToWorldPoint(mousePos);
                StartClickPosition = mousePos;
            }

            if (Input.GetMouseButton(0))
            {
                var mousePos = Input.mousePosition;
                //mousePos.z = 10;
                //CurrentClickPosition = Camera.main.ScreenToWorldPoint(mousePos);
                CurrentClickPosition = mousePos;
            }
            if (Input.GetMouseButtonUp(0))
            {
                var mousePos = Input.mousePosition;
                //mousePos.z = 10;
                //LastClickPosition = Camera.main.ScreenToWorldPoint(mousePos);
                LastClickPosition = mousePos;
            }
        }

        public void RestartInput()
        {
            LastClickPosition = Vector3.zero;
            StartClickPosition = Vector3.zero;
            CurrentClickPosition = Vector3.zero;
        }
    }
}
