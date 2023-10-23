using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    private Rigidbody Rb;

    private int start = 0;
    public float jumpforce = 10;
    float velocity;
    public float maxY, minY;
    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;

        Rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        start = PlayerPrefs.GetInt("Start");
        clamp();
        if (Input.GetKey(KeyCode.Space)&& start == 1)
        {
            thisAnimation.Play();           
            jump();
        }
    }   
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        lose();
    }
    private void jump()
    {
        velocity = jumpforce;

        Rb.AddForce(Vector2.up, ForceMode.Force);
        Rb.AddForce(Vector2.up, ForceMode.Impulse);
        transform.Translate(new Vector3(0, velocity, 0) * Time.deltaTime);        
    }
    private void clamp()
    {
        if (transform.position.y <= minY)
        {
            transform.position = new Vector3(transform.position.x, minY);
            lose();


        }
        else if (transform.position.y >= maxY)
        {
            transform.position = new Vector3(transform.position.x, maxY);
        }
    }
    private void lose()
    {
        SceneManager.LoadScene("Lose");
        start = 0;
        PlayerPrefs.SetInt("Start", 0);
    }
}
