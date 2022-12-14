using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;

namespace MyPlatformer
{
    public class Player : MonoBehaviour
    {

        //Звуки
        [SerializeField] private AudioSource jumpSound;
        [SerializeField] private AudioSource RunSound;

        //Основные переменные
        [SerializeField] public Vector2 MoveVector;
        [SerializeField] public Animator anim;
        [SerializeField] public Rigidbody2D rb;
        [SerializeField] public SpriteRenderer sr;
        [SerializeField] public Transform GroundCheck;
        //Переменные жизней
        [SerializeField] public int lives = 4;
        [SerializeField] private int Maxlives = 4;
        [SerializeField] public Image[] hearts;
        [SerializeField] public Sprite livesfull;
        [SerializeField] public Sprite livesEmpty;
        //Переменные движения
        private bool faceRight = true;
        private NewControls _controlPlayer;
        [SerializeField] private float speedMove;
        [SerializeField] private float jumpForce;
        private bool OnGround;
        [SerializeField] public float checkRadius;
        public LayerMask Ground;
        //Переменные скольжения по стене
        [SerializeField] private float distanceWallSlide;
        [SerializeField] private float speedWallSlide;
        public static Player Instance { get; set; }

        private void Awake()
        {
            _controlPlayer = new NewControls();
            _controlPlayer.ActionMaps.Jump.performed += _ => Jump();
        }

        private void OnEnable()
        {
            _controlPlayer.ActionMaps.Enable();
        }

        private void Start()
        {
            Instance = this;
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            sr = GetComponent<SpriteRenderer>();
        }

        void Update()
        {
            Move();
            WallSlide();
            CheckingGround();
            CheckingLives();
            RestartLevel();
        }

        //Перемещения
        void Move()
        {
            var valueX = _controlPlayer.ActionMaps.Movement.ReadValue<float>();
            transform.Translate(Vector3.right * valueX * speedMove * Time.deltaTime);
            anim.SetFloat("moveX", Mathf.Abs(valueX));
            RunSound.Play();

            //Разворот спрайта
            if ((valueX > 0 && !faceRight) || (valueX < 0 && faceRight))
            {
                transform.localScale *= new Vector2(-1, 1);
                faceRight = !faceRight;
            }
        }

        //Прыжок
        private void Jump ()
        {
            if (OnGround)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpSound.Play();
            }
        }

        //Скольжение по стене
        private void WallSlide()
        {
            Physics2D.queriesStartInColliders = false;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distanceWallSlide);

            if (!OnGround && hit.collider != null)
            {
                if (rb.velocity.y < speedMove)
                {
                    rb.velocity = new Vector2(0, speedWallSlide);
                }
            }
        }

        // Проверка касания земли
        void CheckingGround()
        {
            OnGround = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, Ground);
            anim.SetBool("onGround", OnGround);
        }

        void CheckingLives()
        {
            if (lives > Maxlives)
            {
                lives = Maxlives;
            }
            for (int i = 0; i < hearts.Length; i++)
            {
                if (i < Mathf.RoundToInt(lives))
                {
                    hearts[i].sprite = livesfull;
                }
                else
                {
                    hearts[i].sprite = livesEmpty;
                }
            }
        }

        public void RestartLevel()
        {
            if (lives <= 0)
            {
                SceneManager.LoadScene("First Level");
            }
        }
    }
}