using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPSScript : MonoBehaviour
{
    [SerializeField] private float timeBwtMove;
    [SerializeField] private float timeToWaiting;
    private Transform _trNPS;
    private Animator _animNPS;

    

    void Start()
    {
        _trNPS = GetComponent<Transform>();
        _animNPS = GetComponent<Animator>();
        StartCoroutine(PingPongWithDelay());
    }
    private IEnumerator MoveFromTo(Vector3 startPosition, Vector3 endPosition, float time)
    {
        var currentTime = 0f;
        while (currentTime < time)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, 1 - (time - currentTime) / time);
            currentTime += Time.deltaTime;
            yield return null;
        }
        transform.position = endPosition;
        _animNPS.SetBool("Movement", false);
    }   
    private IEnumerator PingPongWithDelay()
    {
        while (true)
        {
            transform.Rotate(0, 180, 0);
            _animNPS.SetBool("Movement", true);
            yield return MoveFromTo(transform.position, transform.position + new Vector3(10f, 0f, 0f), timeBwtMove);
            yield return new WaitForSeconds(timeToWaiting);


            transform.Rotate(0, -180, 0);
            _animNPS.SetBool("Movement", true);
            yield return MoveFromTo(transform.position, transform.position + new Vector3(-10f, 0f, 0f), timeBwtMove);
            yield return new WaitForSeconds(timeToWaiting);

        }
    }
}
