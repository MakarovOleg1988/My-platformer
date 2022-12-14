using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MyPlatformer
{
    public class CoinScript : Entity
    {
        private int _coinscore = 0;
        [SerializeField] private Text _coinprogress;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<Player>())
            {
                _coinsound.Play();
                _coinscore++;
                _coinprogress.text = _coinscore.ToString();
                Die();
            }
        }
    }
}

