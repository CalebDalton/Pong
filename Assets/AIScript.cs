using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class AIScript : MonoBehaviour
{
    public float speed = 10.0f;
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
        float time = 0.0f;
        float endTime = 5.0f;

        var vel = rb2d.velocity;

        Ball = GameObject.FindGameObjectWithTag("Ball").transform;
        rb2d = Ball.GetComponent<Rigidbody2D>();

        time += Time.deltaTime;

        while (time != endTime) {
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

        while(time == endTime)
        {

        }
    }

    void BadAI()
    {
        if (this.transform.position.y >= 0)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
            Debug.Log(this.transform.position + "Going Down");
        }
        else
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            Debug.Log(this.transform.position + "Going Up");
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
