using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : RewindableObject
{
    public Vector3 direction = new Vector3();

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    //moves in the direction it's given
	protected override void DoCommands()
	{
        Command command = new Move(this, direction, false);
        command.Execute();
        commands.Push(command);
	}
}
