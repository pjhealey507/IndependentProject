using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RewindableObject : MonoBehaviour
{
    public Stack<Command> commands;
	public float speed;

	//the rewindmanager changes the layer to turn off collisions during rewind
	//this is to set it back to normal afterwards
	public int layer;

	protected virtual void Start()
	{
		commands = new Stack<Command>();
		RewindManager.instance.AddRewindableObject(this);
		layer = gameObject.layer;
	}

	//rewindable objects don't do their normal behavior when rewinding
	protected virtual void FixedUpdate()
	{
		if (!RewindManager.instance.rewinding)
		{
			DoCommands();
		}
	}

	protected abstract void DoCommands();
}
