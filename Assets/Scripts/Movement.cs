using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;

    private bool movement_input = false;

    private Rewind rewind;

    void Awake()
    {
        rewind = GetComponent<Rewind>();
    }

    void Update()
    {
        movement_input = Input.GetKey(KeyCode.D);

        rewind.AddMovementTrack(movement_input);

        if (movement_input)
        {
            Execute(Direction.Right);
        }
    }

    public void Execute(Direction direction)
    {
        Vector3 movement_force = (int)direction * Vector3.right * Time.deltaTime * speed;

        transform.Translate(movement_force);
    }
}

public enum Direction { Left = -1, Right = 1};
