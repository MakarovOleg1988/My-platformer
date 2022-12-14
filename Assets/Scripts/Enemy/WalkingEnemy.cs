using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyPlatformer
{
    public class WalkingEnemy : Entity
    {

        public float speed;
        public float distance;
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
            RaycastHit2D groundInfo = Physics2D.Raycast(GroundDetection.position, Vector2.down, distance);

            if (groundInfo.collider == false)
            {
                if (moovingRight == true)
                {
                    transform.eulerAngles = new Vector2(0, 0);
                    moovingRight = false;
                }
                else
                {
                    transform.eulerAngles = new Vector2(0, -180);
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
