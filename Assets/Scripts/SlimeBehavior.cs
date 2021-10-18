using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBehavior : MonoBehaviour
{
    public float pushBackForce = 3;
    public AudioSource boingSource;

    void Start()
    {
        boingSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Player"))
        {
            boingSource.Play();
            Player player = col.transform.root.GetComponentInChildren<Player>();
            Vector2 colNormal = col.transform.position - transform.position;
            colNormal.Normalize();
            player.Pushback(colNormal * pushBackForce);
            CameraController.ScreenShakeLight();
        }
    }



}

