using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//For movement for all characters
//modify for four directional movement

public class Move : Command
{
	Vector3 direction;

	public Move(RewindableObject s, Vector3 direction) : base(s)
	{
		this.direction = direction;
	}

	public override void Execute()
	{
		sender.transform.Translate(new Vector3(direction.x * sender.speed * Time.deltaTime, direction.y * sender.speed * Time.deltaTime, 0));
	}

	public override void Reverse()
	{
		sender.transform.Translate(new Vector3(-direction.x * sender.speed * Time.deltaTime, -direction.y * sender.speed * Time.deltaTime, 0));
	}
}
