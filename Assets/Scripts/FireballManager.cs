using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballManager : MonoBehaviour
{
    public float floatForce;
    public float pushForce;
    public float speed;
    public int directionRay; //positive right, negative left
    public bool type; //true float, false push

    private Rigidbody2D rb;
    private PolygonCollider2D pc;
    private Renderer r;

    private float timepassed;
    private bool hitSomething;


    // Start is called before the first frame update
    void Start()
    {
        hitSomething = false;
        transform.position = transform.position + new Vector3(directionRay, -0.2f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(directionRay, 0, 0) * speed * Time.deltaTime;
        timepassed += Time.deltaTime;
        if ((timepassed>= 10) && (!hitSomething)) {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.CompareTag("Player"))
        {
            hitSomething = true;
            if (type)
            {
                //make player float
                rb = c.gameObject.GetComponent<Rigidbody2D>();
                pc = GetComponent<PolygonCollider2D>();
                r = GetComponent<Renderer>();
                rb.velocity = new Vector2(0,3);
                rb.mass = 0.2f;
                rb.gravityScale = 0.2f;
                StartCoroutine(WaitToDestroy());
            }
            else {
                //push player back
                Player player = c.gameObject.GetComponent<Player>();
                player.Pushback(new Vector2(directionRay*4,0));
                Destroy(gameObject);
            }
        }
    }

    IEnumerator WaitToDestroy()
    {
        r.enabled = false;
        pc.enabled = false;

        yield return new WaitForSeconds(1);
        
        rb.mass = 1.0f;
        rb.gravityScale = 1.0f;

        Destroy(gameObject);
    }
}
