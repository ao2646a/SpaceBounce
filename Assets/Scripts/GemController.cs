using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemController : MonoBehaviour
{
    // this script controlls the spawning of gems and activates the player's special abilities.

    public bool canFloat;
    public bool canPush;

    public float secTilGenerate;
    private float timeSoFar;

    private bool isSpawned;


    // Start is called before the first frame update
    void Start()
    {
        isSpawned = false;
        timeSoFar = 0;

        //making sure that the gem only allows one ability max.
        if (canFloat) 
        {
            canPush = false;
        }

        visible(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSpawned) {
            timeSoFar += Time.deltaTime;
        }
        if (timeSoFar >= secTilGenerate) {
            isSpawned = true;
            visible(true);
        }

    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.CompareTag("Player") && isSpawned)
        {
            if (canFloat) {
                c.gameObject.GetComponent<Player>().shootFloat = true;
                c.gameObject.GetComponent<Player>().shootPush = false;
                c.gameObject.GetComponent<Player>().timeToShoot = 10.0f;
            } else {
                c.gameObject.GetComponent<Player>().shootPush = true;
                c.gameObject.GetComponent<Player>().shootFloat = false;
                c.gameObject.GetComponent<Player>().timeToShoot = 10.0f;
            }
            visible(false);
            timeSoFar = 0;
            isSpawned = false;
           
        }
    }

    void visible(bool v) {
        GetComponent<Renderer>().enabled = v;
        GetComponent<PolygonCollider2D>().enabled = v;
    }

    }
