using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Manages if the scene is in reverse or not, and controls how many actions are reversed

public class RewindManager : MonoBehaviour
{
    //Singleton
    public static RewindManager instance { get; private set; }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

        //has to be in awake for the player to be added to the list
        rewindable_objects = new List<RewindableObject>();
    }

    public bool rewinding = false;
    private List<RewindableObject> rewindable_objects;

	// Update is called once per frame
	void FixedUpdate()
    {
        if (rewinding)
        {
            //applies to all rewindable objects
            foreach (RewindableObject c in rewindable_objects)
            {
                //execute the reverse of the command
                c.commands.Pop().Reverse();
            }
        }
    }

    public void EnterRewind()
    {
        rewinding = true;
    }

    public void ExitRewind()
    {
        //stop rewinding after 
        rewinding = false;
    }

    public void AddRewindableObject(RewindableObject r)
    {
        rewindable_objects.Add(r);
    }

    public void RemoveRewindableObject(RewindableObject r)
    {
        rewindable_objects.Remove(r);
    }
}