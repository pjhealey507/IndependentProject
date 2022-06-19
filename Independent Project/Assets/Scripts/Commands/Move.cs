using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//For movement for all rewindable objects
public class Move : Command
{
	Vector3 direction;
	Vector3 start_loc;

	public Move(RewindableObject s, Vector3 direction) : base(s)
	{
		this.direction = direction;
		start_loc = sender.transform.position;
	}

	public override void Execute()
	{
		sender.GetComponent<Rigidbody2D>().AddForce(new Vector2(direction.x * sender.speed * Time.deltaTime, direction.y * sender.speed * Time.deltaTime));
	}

	public override void Reverse()
	{
		sender.transform.position = start_loc;
	}
}
