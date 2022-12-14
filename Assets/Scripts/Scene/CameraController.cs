using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyPlatformer
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private float _speedMovementCamera;
        private Vector3 pos;

        private void Awake()
        {
            if (!player)
                player = FindObjectOfType<Player>().transform;
        }
        private void Update()
        {
            pos = player.position;
            pos.z = -10f;
            transform.position = Vector3.Lerp(transform.position, pos, _speedMovementCamera * Time.deltaTime);
        }
    }
}
