using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rewind : MonoBehaviour
{
    public GameObject canvas;

    private List<bool> movement_track = new List<bool>();
    public static bool rewind_active = false;

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
                DeleteFramesUntilMovement();
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

    private void DeleteFramesUntilMovement()
    {
        int length = movement_track.Count;


        while(length-1 > 0 && movement_track[length-1] == false)
        {
            movement_track.RemoveAt(length - 1);
            length--;
        }
    }

    IEnumerator Rewind_CO()
    {
        int length = movement_track.Count;
        int actual_index = length - 1;

        while (rewind_active && actual_index >= 0)
        {
            bool movement_input = movement_track[actual_index];
            movement_track.RemoveAt(actual_index);

            if (movement_input)
            {
                if(!jump.jumping)
                    movement.Execute(Direction.Left);
            }
                
            actual_index--;

            yield return new WaitForEndOfFrame();
        }
    }

    public void AddMovementTrack(bool movement_input)
    {
        movement_track.Add(movement_input);
    }
}
