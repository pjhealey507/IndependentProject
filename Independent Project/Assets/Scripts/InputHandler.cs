using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler 
{
    KeyCode move_right = KeyCode.D;
    KeyCode move_left = KeyCode.A;
    KeyCode move_up = KeyCode.W;
    KeyCode move_down = KeyCode.S;
    KeyCode rewind = KeyCode.R;

    public Command GetInput(Character sender)
    {
        Command command;
        int direction_x = 0;
        int direction_y = 0;

        if (Input.GetKey(move_right))
        {
            direction_x = 1;
        }
        if (Input.GetKey(move_left))
        {
            direction_x = -1;
        }

        if (Input.GetKey(move_up))
        {
            direction_y = 1;
        }
        if (Input.GetKey(move_down))
        {
            direction_y = -1;
        }

        if (direction_x != 0 || direction_y != 0)
        {
            Vector3 direction = new Vector3(direction_x, direction_y, 0);
            command = new Move(sender, direction, sender.colliding);
        }
        else
        {
            command = new Wait(sender);
        }

        return command;
    }

    public void GetRewind()
    {
        if (Input.GetKeyUp(rewind))
        {
            Debug.Log("Exit rewind");
            RewindManager.instance.ExitRewind();
        }

        if (Input.GetKeyDown(rewind))
        {
            Debug.Log("Enter rewind");
            RewindManager.instance.EnterRewind();
        }
    }
}
