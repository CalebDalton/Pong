using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class AIScript : MonoBehaviour
{
    public float speed = 7.5f;
    Transform Ball;

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
        rb2d = Ball.GetComponent<Rigidbody2D>();

        if (rb2d.velocity.x < 0)
        {
            if (Ball.position.y < this.transform.position.y)
            {
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
            else if (Ball.position.y > this.transform.position.y)
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
        }
    }

    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, boundY.x * -1 + objectWidth, boundY.x - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, boundY.y * -1 + objectHeight, boundY.y - objectHeight);
        transform.position = viewPos;
    }
}
