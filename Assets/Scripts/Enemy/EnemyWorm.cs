using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyPlatformer
{
    public class EnemyWorm : Entity
    {
        [SerializeField] private int _livesEnemyWorm;
        [SerializeField] public GameObject energyBall;
        [SerializeField] public Transform firePoint;
        [SerializeField] private float timeBetweenShots;
        [SerializeField] private float startTimeShoot ;

        private void Start()
        {
            timeBetweenShots = startTimeShoot;
        }

        private void Update()
        {
            Shoot();
        }

        //Проверка столкновения с героем и нанесение ему урона
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject == Player.Instance.gameObject)
            {
                _damagesound.Play();
                GetDamage();
            }
        }

        void Shoot()
        {
            if (timeBetweenShots <= 0)
            {
                Instantiate(energyBall, firePoint.position, Quaternion.identity);
                timeBetweenShots = startTimeShoot;
            }
            else
            {
                timeBetweenShots -= Time.deltaTime;
            }
        }
    }
}