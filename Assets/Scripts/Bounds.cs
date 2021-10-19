using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bounds : MonoBehaviour
{
    public Text resultText;
    public AudioSource endGameSource;

    // Start is called before the first frame update
    void Start()
    {
        endGameSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !resultText.enabled)
        {
            if (other.gameObject.name == "Player 1")
            {
                endGameSource.Play();
                resultText.text = "Player 2 wins!";
                resultText.enabled = true;
            }

            else if (other.gameObject.name == "Player 2 Variant 1")
            {
                endGameSource.Play();
                resultText.text = "Player 1 wins!";
                resultText.enabled = true;
            }

            StartCoroutine(EndRound());
        }
    }

    IEnumerator EndRound()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("Main");
    }
}
