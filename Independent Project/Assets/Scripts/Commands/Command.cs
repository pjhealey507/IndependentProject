using System.Collections;
using System.Collections.Generic;

public abstract class Command
{
    public RewindableObject sender;

    public Command(RewindableObject s)
    {
        sender = s;
    }

    public abstract void Execute();
    public abstract void Reverse();
}
