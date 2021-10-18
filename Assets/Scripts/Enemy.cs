using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Sprite[] enemySprite = new Sprite[2];
    public int animationSpeed; //how fast the frames switch - smaller it is, faster the frame switches

    private int direction = 1;
    private int spriteIndex = 0;
    

    private Rigidbody2D rb;
    private SpriteRenderer sr;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        sr.flipX = true;
    }

    void Update()
    {
        UpdateDirection();

        Vector2 vel = rb.velocity;
        vel.x = direction * speed;
        rb.velocity = vel;

        spriteIndex++;
        if (spriteIndex % animationSpeed == 0) {
            sr.sprite = enemySprite[(spriteIndex / animationSpeed) -1];
        }
        if (spriteIndex == animationSpeed * enemySprite.Length) {
            spriteIndex = 1;
        }
    }

    int UpdateDirection()
    {
        //raycasting out 2 rays on either side to determine whether the direction of the enemy shoyld change
        Vector3 rayStartLeft = transform.position + Vector3.up * 0.1f + Vector3.left * 0.9f;
        Vector3 rayStartRight = transform.position + Vector3.up * 0.1f + Vector3.right * 0.9f;

        RaycastHit2D hitLeft = Physics2D.Raycast(rayStartLeft, Vector2.down, 1f);
        RaycastHit2D hitRight = Physics2D.Raycast(rayStartRight, Vector2.down, 1f);

        if (hitLeft.collider == null)
        {
            sr.flipX = true;
            direction = 1;
        }

        if (hitRight.collider == null)
        {
            sr.flipX = false;
            direction = -1;
        }

        return direction;
    }


}
