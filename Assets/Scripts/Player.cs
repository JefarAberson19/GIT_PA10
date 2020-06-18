using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static GameManager thisManager = null;
    private Animation thisAnimation;
    public float Fly;
    public float score;
    public Rigidbody rb;
    public Text Score;
    

    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            thisAnimation.Play();
            rb.velocity = (transform.up * Fly);
        }
        if(score >= 100)
        {
            SceneManager.LoadScene("Win");
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "bad")
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Lose");
        }
        if(other.gameObject.tag == "safe")
        {
            score += 10;
            Score.text = "SCORE : " + score;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "bad")
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Lose");
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
