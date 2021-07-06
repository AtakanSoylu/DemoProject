using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Demo.Character
{

    [CreateAssetMenu(menuName = "Demo/Character/Character Settings")]
    public class CharacterControllerSettings : ScriptableObject
    {
        [SerializeField] private float _straightSpeed;
        public float StraightSpeed { get { return _straightSpeed; } }   

        [SerializeField] private float _leftRightSpeed;
        public float LeftRightSpeed { get { return _leftRightSpeed; } }
    }
}
