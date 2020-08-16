using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Paddle paddle;
    private Vector3 paddleToBallVector;
    public Rigidbody2D rigi2d;
    private bool hasStarted = false;

    // Use this for initialization
    void Start () {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
        rigi2d = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update () {
        if (!hasStarted)
        {
            // Lock the ball relative to the paddle.
            this.transform.position = paddleToBallVector + paddle.transform.position;
            
            //Wait for a mouse press to launch.
            if (Input.GetMouseButtonDown(0))
            {
                this.rigi2d.velocity = new Vector2(2f, 10f);
                hasStarted = true;
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
        if (hasStarted)
        {
            GetComponent<AudioSource>().Play();
            rigi2d.velocity += tweak;
        }
    }
}
