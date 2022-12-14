using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyPlatformer
{
    public class EnemyEnergyball : Entity
    {
        [SerializeField] private float _speedMove = 4f;
        public Rigidbody2D _rbEnergyBall;

        private void Start()
        {
            _rbEnergyBall.velocity = -transform.right * _speedMove;
        }


        public void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject == Player.Instance.gameObject)
            {
                Die();
                GetDamage();
            }
            else
            {
                Die();
            }
        }
    }
}
