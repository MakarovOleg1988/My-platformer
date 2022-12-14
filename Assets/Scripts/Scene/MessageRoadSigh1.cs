using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MyPlatformer
{
    public class MessageRoadSigh1 : MonoBehaviour
    {
        public GameObject panelDialog;
        [SerializeField] public Text TextStory;
        public string[] _message;
        private bool dialogStart = false;

        void Start()
        {
            _message[0] = "Великие Путешествия ждут тебя впереди, путник!";
            _message[1] = "Но и опасностей много будет на твоем пути! Будь осторожен!";
        }

        public void Update()
        {
            if (dialogStart == true)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    TextStory.text = _message[1];
                }
            }
        }


        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<Player>())
            {
                panelDialog.SetActive(true);
                TextStory.text = _message[0];
                dialogStart = true;
            }
        }

        public void OnTriggerExit2D(Collider2D other)
        {
            panelDialog.SetActive(false);
            dialogStart = false;
        }
    }
}
