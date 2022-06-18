using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//For movement for all rewindable objects
public class Move : Command
{
	Vector3 direction;
	bool executed = true;

	public Move(RewindableObject s, Vector3 direction, bool colliding) : base(s)
	{
		this.direction = direction;
	}

	public override void Execute()
	{
		sender.GetComponent<Rigidbody2D>().AddForce(new Vector2(direction.x * sender.speed * Time.deltaTime, direction.y * sender.speed * Time.deltaTime));

		float coll_threshold = 1f;

		//if the movement was blocked, dont reverse
		//if sender is colliding, further movements will screw up the rewinding
		if (sender.GetComponent<Rigidbody2D>().velocity.x <= coll_threshold && sender.GetComponent<Rigidbody2D>().velocity.x >= -coll_threshold && sender.GetComponent<Rigidbody2D>().velocity.y <= coll_threshold && sender.GetComponent<Rigidbody2D>().velocity.y >= -coll_threshold)
		{
			executed = false;
		}
	}

	public override void Reverse()
	{
		//if the movement was blocked, dont reverse
		if (executed)
		{
			sender.GetComponent<Rigidbody2D>().AddForce(new Vector2(-direction.x * sender.speed * Time.deltaTime, -direction.y * sender.speed * Time.deltaTime));
		}
	}
}
