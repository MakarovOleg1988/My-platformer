using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
 
    [SerializeField] private AudioSource Button;

    public void Start()
    {
        StartCoroutine(Coroutine1());
    }

    public IEnumerator Coroutine1()
    {
    Button.Play();
    yield return new WaitForFixedUpdate();
    SceneManager.LoadScene(1);
    }
}
