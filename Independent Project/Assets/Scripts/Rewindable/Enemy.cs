using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//stays a certain distance from the player, moves in circles around the player
public class Enemy : RewindableObject
{
    //enemy stays a certain distance away
    public float max_distance;
    public float min_distance;
    public float cur_distance;

    //enemy revolves clockwise or counterclockwise around the player
    public bool clockwise;
    public GameObject player;

    private Vector3 direction;

    private float max_speed;

	protected override void FixedUpdate()
	{
        DetermineDirection();
		base.FixedUpdate();
	}

	protected override void DoCommands()
	{
        Command command = new Move(this, direction);
        command.Execute();
        commands.Push(command);
	}

    void DetermineDirection()
    {
        cur_distance = Vector3.Distance(player.transform.position, this.transform.position);
        Debug.Log("cur_distance: " + cur_distance);

        //player is too close
        if (cur_distance < min_distance)
        {
            //move away from player
            direction += -(player.transform.position - this.transform.position);

            speed *= ((cur_distance - min_distance) / 100);

            Debug.Log((cur_distance - min_distance) / 100);
        }

        //player is too far
        if (cur_distance > max_distance)
        {
            //move towards player
            direction += (player.transform.position - this.transform.position);

            speed *= ((cur_distance - max_distance)/100);

            Debug.Log((cur_distance - max_distance)/100);
        }

        /*
        if (speed > max_speed)
        {
            speed = max_speed;
        }
        */
        if (speed <= 0)
        {
            speed = 1;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
