using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyPlatformer
{
    public class Apple : Entity
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject == Player.Instance.gameObject)
            {
                _applesound.Play();
                GetLive();
                Die();
            }
        }
    }
}