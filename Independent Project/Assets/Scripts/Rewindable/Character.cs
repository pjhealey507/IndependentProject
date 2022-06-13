using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//remove
using TMPro;

public class Character : RewindableObject
{
    public int hp;
    public int max_hp;

    //to prevent move commands into a wall
    public bool colliding;

    //remove
    public TMP_Text hp_text;

    public Character()
    {
        hp = max_hp;
    }

    protected override void DoCommands()
    {

    }

    public virtual void Die()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Damaging>() != null)
        {
            Command command = new LoseHealth(this, collision.gameObject.GetComponent<Damaging>().damage);
            command.Execute();
            commands.Push(command);
        }

        else
        {
            colliding = true;
        }
    }

	private void OnCollisionExit2D(Collision2D collision)
	{
        Debug.Log("coll exit");
        colliding = false;
	}
}
