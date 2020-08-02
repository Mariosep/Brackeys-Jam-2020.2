using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rewind : MonoBehaviour
{
    public GameObject canvas;

    private List<bool> movement_track = new List<bool>();
    private List<bool> jump_track = new List<bool>();

    private bool rewind_active = false;

    private Movement movement;
    private Jump jump;

    void Awake()
    {
        movement = GetComponent<Movement>();
        jump = GetComponent<Jump>();
    }

    void Update()
    {
        if (!rewind_active)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                rewind_active = true;
                canvas.SetActive(true);
                StartCoroutine(Rewind_CO());
            }
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.R))
            {
                rewind_active = false;
                canvas.SetActive(false);
            }
        }
    }

    IEnumerator Rewind_CO()
    {
        int length = movement_track.Count;
        int actual_index = length - 1;

        Debug.Log("MovementTrack: " + movement_track.Count);
        Debug.Log("JumpTrack: " + jump_track.Count);

        while (rewind_active && actual_index >= 0)
        {
            bool movement_input = movement_track[actual_index];
            movement_track.RemoveAt(actual_index);

            if (movement_input)
                movement.Execute(Direction.Left);

            bool jump_input = jump_track[actual_index];
            jump_track.RemoveAt(actual_index);

            if (jump_input)
                jump.Execute();

            actual_index--;

            yield return new WaitForEndOfFrame();
        }
    }

    public void AddMovementTrack(bool movement_input)
    {
        movement_track.Add(movement_input);
    }

    public void AddJumpTrack(bool jump_input)
    {
        jump_track.Add(jump_input);
    }
}
