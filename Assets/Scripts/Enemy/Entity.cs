using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyPlatformer
{
    public class Entity : MonoBehaviour
    {
        [SerializeField] protected AudioSource _damagesound;
        [SerializeField] protected AudioSource _damageallsound;
        [SerializeField] protected AudioSource _applesound;
        [SerializeField] protected AudioSource _coinsound;

        public virtual void GetDamage()
        {
            Player.Instance.lives -= 1;
        }

        public virtual void GetDamageAll()
        {
            Player.Instance.lives -= 10;
        }
        public virtual void GetLive()
        {
            Player.Instance.lives += 1;
        }

        public virtual void Die()
        {
            Destroy(this.gameObject);
        }


    }
}
