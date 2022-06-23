using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait : Command
{
	Vector3 start_loc;

	public Wait(RewindableObject s) : base(s)
	{
		sender = s;
		start_loc = sender.transform.position;
	}

	public override void Execute()
	{
		
	}

	public override void Reverse()
	{
		sender.transform.position = start_loc;
	}
}
