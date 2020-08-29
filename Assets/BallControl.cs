using System;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float thrust = 120.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("GoBall", 2);
        InvokeRepeating("SpeedUp", 1.0f, 5.0f);
    }

    void SpeedUp()
    {
        rb2d.mass -= .002f;
        Debug.Log(rb2d.mass);
    }

    void GoBall()
    {
        float rand = UnityEngine.Random.Range(0, 2);
        int randX;
        int randY;

        randX = UnityEngine.Random.Range(10, 17);
        do {
            randY = UnityEngine.Random.Range(-17, 17);
        } while (randY == 0);

        Debug.Log(randX + ", " + randY);

        if (rand == 0)
        {
            rb2d.AddForce(new Vector2(randX, randY), ForceMode2D.Force);
        }
        else
        {
            rb2d.AddForce(new Vector3(randX * -1, randY, 0), ForceMode2D.Force);
        }
    }

    void ResetBall()
    {
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
        rb2d.mass = .025f;
    }

    void RestartGame()
    {
        ResetBall();
        Invoke("GoBall", 1);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            Vector2 vel;
            vel.x = rb2d.velocity.x;
            vel.y = (rb2d.velocity.y) + (coll.collider.attachedRigidbody.velocity.y / 3);
            rb2d.velocity = vel;
        }
    }
}
