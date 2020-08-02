using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float force = 5f;

    private Rigidbody2D rb;
    private bool jump_input = false;
    public bool jumping = false;
    public bool wasJumping_previousFrame = false;

    private Rewind rewind;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rewind = GetComponent<Rewind>();
    }

    void Update()
    {
        jump_input = Input.GetButtonDown("Jump");

        if (jump_input && !jumping)
        {
            Execute();
            jumping = true;
            rewind.AddJumpTrack(false);
        }
        else if (wasJumping_previousFrame && !jumping)
        {
            rewind.AddJumpTrack(true);
        }
        else
        {
            rewind.AddJumpTrack(false);
        }

        wasJumping_previousFrame = jumping;
    }

    public void Execute()
    {
        Vector3 jump_force = Vector3.up * Time.fixedDeltaTime * force;

        rb.AddForce(jump_force, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        jumping = false;
    }
}
