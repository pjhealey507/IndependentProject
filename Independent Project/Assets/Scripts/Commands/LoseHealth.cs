using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseHealth : Command
{
	int damage;

	public LoseHealth(Character s, int d) : base(s)
	{
		sender = s;
		damage = d;
	}

	public override void Execute()
	{
		Character character = sender.GetComponent<Character>();

		character.hp -= damage;
		if (character.hp <= 0)
		{
			character.Die();
		}
	}

	public override void Reverse()
	{
		Character character = sender.GetComponent<Character>();

		character.hp += damage;
		if (character.hp > character.max_hp)
		{
			character.hp = character.max_hp;
		}
	}
}
