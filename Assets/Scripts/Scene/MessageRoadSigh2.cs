using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MyPlatformer
{
    public class MessageRoadSigh2 : MonoBehaviour
    {
        public GameObject panelDialog;
        public Text dialog;
        public string[] message;
        private bool dialogStart = false;

        void Start()
        {
            message[0] = "Великие герои покоятся здесь!";
            message[1] = "Высоко в горах никто их не побеспокоит";
            panelDialog.SetActive(false);
        }

        private void Update()
        {
            if (dialogStart == true)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    dialog.text = message[1];
                }
            }
        }


        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<Player>())
            {
                panelDialog.SetActive(true);
                dialog.text = message[0];
                dialogStart = true;
            }
        }

        public void OnTriggerExit2D(Collider2D other)
        {
            if (other.GetComponent<Player>())
            {
                panelDialog.SetActive(false);
                dialogStart = false;
            }
        }
    }
}
