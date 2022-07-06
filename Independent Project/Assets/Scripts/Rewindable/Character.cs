using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//remove
using TMPro;

public class Character : RewindableObject
{
    public int hp;
    public int max_hp;

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
        //particle effects

        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Damaging>() != null)
        {
            Command command = new LoseHealth(this, collision.gameObject.GetComponent<Damaging>().damage);
            command.Execute();
            commands.Push(command);

            if (hp <= 0)
            {
                Die();
            }
        }
    }
}
