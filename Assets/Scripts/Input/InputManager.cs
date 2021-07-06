using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Demo.PlayerInput
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private InputData _inputData;

        private void Awake()
        {
            _inputData.RestartInput();
        }
        private void Update()
        {
            _inputData.ProcessInput();
        }
    }
}