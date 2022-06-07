using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rewind : Command
{
	public Rewind(Character s) : base(s)
	{
		sender = s;
	}

	public override void Execute()
	{
		//reverse all characters using manager
		RewindManager.instance.EnterRewind();
	}

	public override void Reverse()
	{
		//none
	}
}
