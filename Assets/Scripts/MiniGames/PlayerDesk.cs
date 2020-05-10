using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDesk : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 15f;
    public float mapWidh = 500f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed;

        Vector2 newPosition = rb.position + Vector2.right * x;

        newPosition.x = Mathf.Clamp(newPosition.x, 300,mapWidh);

        rb.MovePosition(newPosition);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
