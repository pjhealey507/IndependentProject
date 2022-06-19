using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop : Command
{
	public Stop(RewindableObject s) : base(s)
	{
		
	}

	public override void Execute()
	{
		Rigidbody2D rb = sender.GetComponent<Rigidbody2D>();

		rb.AddForce(new Vector2(-rb.velocity.x, -rb.velocity.y));
	}

	public override void Reverse()
	{
		
	}
}
