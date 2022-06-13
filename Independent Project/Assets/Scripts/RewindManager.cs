using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    public TMP_Text rewinding_text;

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
        rewinding_text.gameObject.SetActive(true);

        //no collision during rewind
        foreach (RewindableObject c in rewindable_objects)
        {
            //c.GetComponent<Rigidbody2D>().simulated = false;
        }
    }

    public void ExitRewind()
    {
        rewinding = false;
        rewinding_text.gameObject.SetActive(false);

        //turn it back on after
        foreach (RewindableObject c in rewindable_objects)
        {
            c.GetComponent<Rigidbody2D>().simulated = true;
        }
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