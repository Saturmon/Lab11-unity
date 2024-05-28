using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rebote : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;
    public float velocity;
    public float xDirection;
    public float yDirection;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        rigidbody2D.position = new Vector2(rigidbody2D.position.x + velocity * xDirection * Time.deltaTime, rigidbody2D.position.y + velocity * yDirection * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pared de lado")
        {
            xDirection = -1;
            spriteRenderer.flipX = true;
        }
        if (collision.gameObject.tag == "Pared del otro lado")
        {
            xDirection = +1;
            spriteRenderer.flipX = false;
        }
        if (collision.gameObject.tag == "Techo")
        {
            yDirection = -1;
            spriteRenderer.flipY = true;
        }
        if (collision.gameObject.tag == "Piso")
        {
            yDirection = +1;
            spriteRenderer.flipY = false;
        }
    }
}