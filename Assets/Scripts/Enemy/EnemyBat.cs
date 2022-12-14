using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyPlatformer
{
    public class EnemyBat : Entity
    {
        private Rigidbody2D _rbEnemyBat;
        [SerializeField] private Transform player;
        [SerializeField] private float speed;
        [SerializeField] private float agroDistance;

        void Start()
        {
            _rbEnemyBat = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            float distToPlayer = Vector2.Distance(transform.position, player.position);
            if (distToPlayer < agroDistance)
            {
                StartHunting();
            }
            else
            {
                StopHunting();
            }
        }

        void StartHunting()
        {
            if (player.position.x < transform.position.x)
            {
                _rbEnemyBat.velocity = new Vector2(-speed, 0);
            }
            else if ((player.position.x > transform.position.x))
            {
                _rbEnemyBat.velocity = new Vector2(speed, 0);
            }
        }

        void StopHunting()
        {
            _rbEnemyBat.velocity = new Vector2(0, 0);
        }

        //Столкновение с персонажем
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject == Player.Instance.gameObject)
            {
                GetDamage();
            }
        }
    }
}