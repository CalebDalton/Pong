using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIScript : MonoBehaviour
{
    public float speed = 20.0f;
    Transform Ball;
    Transform Ai;

    private Vector2 boundY;
    private float objectWidth;
    private float objectHeight;

    private Rigidbody2D rb2d;
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        boundY = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;

        
    }

    // Update is called once per frame
    void Update()
    {
        var vel = rb2d.velocity;

        Ball = GameObject.FindGameObjectWithTag("Ball").transform;

        if(rb2d.velocity.x < 0)
        {
            if(Ball.position.y < this.transform.position.y)
            {

            }
        }
        else
        {

        }
    }
}
