using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsController : MonoBehaviour
{
    public GameObject scoreParticle;

    [SerializeField]
    private float transitionTo = 1f;
    

    private void Start()
    {
        LeanTween.moveLocalY(gameObject, transitionTo, 4).setEaseInOutSine().setLoopPingPong();
        LeanTween.rotateY(gameObject, 45, 3).setEaseInOutSine().setLoopPingPong();
    }
        
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Score += 5f;
            Instantiate(scoreParticle, gameObject.transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
            Destroy(gameObject);
        }
    }
}
