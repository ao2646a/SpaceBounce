using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D rb;
    private BoxCollider2D bc;
    private float inputX;

    public float lastJumpTime;
    public bool grounded;

    public float pushBackForce = 8;


    public AudioSource bounceSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        bounceSource = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector2(inputX * moveSpeed, 0));
    }

    public void Move(InputAction.CallbackContext context)
    {
        inputX = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            bounceSource.Play();
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    private bool IsGrounded()
    {
        float extraHeight = .02f;
        RaycastHit2D raycastHit = Physics2D.Raycast(bc.bounds.center, Vector2.down, bc.bounds.extents.y + extraHeight);
        return raycastHit.collider != null;
    }


    public void Pushback(Vector2 force)
    {
        rb.velocity = force;
        lastJumpTime = Time.time;
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D other)

        {
            if (other.gameObject.CompareTag("Player"))
            {
                Player player = other.transform.root.GetComponentInChildren<Player>();
                Vector2 colNormal = other.transform.position - transform.position;
                colNormal.Normalize();
                player.Pushback(colNormal * pushBackForce);
                CameraController.ScreenShakeLight();
        }
        }

    }

