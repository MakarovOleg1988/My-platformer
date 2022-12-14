using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyPlatformer
{
    public class WalkingEnemyForWall : Entity
    {
        //Основные переменные
        [SerializeField, Range(1,10)] float speed;
        [SerializeField] private float distance;
        private bool moovingRight = true;
        public Transform GroundDetection;

        private void Update()
        {
            Move();
        }

        //Перемещение
        private void Move()
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);

            RaycastHit2D groundInfo = Physics2D.Raycast(GroundDetection.position, Vector2.left, distance);

            if (groundInfo.collider == true && moovingRight == true)
            {
                {
                    transform.eulerAngles = new Vector2(0, 0);
                    moovingRight = false;
                }

                if (groundInfo.collider == true && moovingRight == false)
                {
                    transform.eulerAngles = new Vector2(0, 180);
                    moovingRight = true;
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject == Player.Instance.gameObject)
            {
                GetDamage();
            }
        }
    }
}