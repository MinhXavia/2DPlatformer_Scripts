using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    float horizontal;

    private float speed = 4f;
    private float jumpForce = 6.5f;

    void Start()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");     //right, left arrow
        float vertical = Input.GetAxis("Vertical");
        transform.position += new Vector3(horizontal, 0, 0) * Time.deltaTime * speed;     // Time.deltaTime: to smoothen movement over the frames

        if (Input.GetButtonDown("Jump") && Mathf.Abs(rigidbody2D.velocity.y) < 0.001f)
        {
            rigidbody2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }
}
