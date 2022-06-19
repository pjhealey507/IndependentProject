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

	protected override void Start()
	{
        player = FindObjectOfType<PlayerControl>().gameObject;
		base.Start();
	}

	protected override void FixedUpdate()
	{
        DetermineDirection();
		base.FixedUpdate();
	}

	protected override void DoCommands()
	{
        Command command;

        //in sweet spot
        if (cur_distance < max_distance && cur_distance > min_distance)
        {
            command = new Stop(this);
        }
        else
        {
            command = new Move(this, direction);
        }

        command.Execute();
        commands.Push(command);
	}

    void DetermineDirection()
    {
        cur_distance = Vector3.Distance(player.transform.position, this.transform.position);

        //player is too close
        if (cur_distance < min_distance)
        {
            //move away from player
            direction = -(player.transform.position - this.transform.position);
        }

        //player is too far
        if (cur_distance > max_distance)
        {
            //move towards player
            direction = (player.transform.position - this.transform.position);
        }

        direction = direction.normalized;
    }
}
