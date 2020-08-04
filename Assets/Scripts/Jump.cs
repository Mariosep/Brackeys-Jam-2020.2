using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public bool jumping = false;

    [Range(0.1f, 1f)]
    public float inclination = 0.5f;
    public float impulse_force = 100f;

    private Rigidbody2D rb;
    private Movement movement;
    private Fall fall;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = GetComponent<Movement>();
        fall = GetComponent<Fall>();
    }

    public void Execute(Direction direction, int fallen_hight)
    {
        Vector2 final_direction = new Vector2((int)direction * inclination, 1f);
        rb.AddForce(final_direction * impulse_force * (fallen_hight + 1), ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Jumper") && !jumping)
        {
            if(Rewind.rewind_active)
                Execute(Direction.Left, fall.fallen_height);
            else
                Execute(Direction.Right, fall.fallen_height);

            jumping = true;
            movement.movement_blocked = true;
            fall.fallen_height = 0;
        }
        else if (collision.collider.CompareTag("Jumper") && jumping)
        {
            if(Rewind.rewind_active)
                Execute(Direction.Left, fall.fallen_height);
            else
                Execute(Direction.Right, fall.fallen_height);

            fall.fallen_height = 0;
        }
        else if (jumping)
        {
            movement.movement_blocked = false;
            jumping = false;
        }
    }
}
