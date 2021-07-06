using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Demo.Camera
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private GameObject player;

        [SerializeField] private Vector3 _offset;

        void Start()
        {
        }

        void FixedUpdate()
        {
            Vector3 flatSpeed = player.GetComponent<Rigidbody>().velocity;
            flatSpeed.y = 0;

            Quaternion wantedRotation = Quaternion.Euler(0,0,0);

            if (flatSpeed != Vector3.zero)
            {
                float targetAngle = Quaternion.LookRotation(flatSpeed).eulerAngles.y;
                wantedRotation = Quaternion.Euler(0, targetAngle, 0);
            }

            transform.position = player.transform.position + (wantedRotation * _offset);
            transform.LookAt(player.transform);
        }
    }
}
