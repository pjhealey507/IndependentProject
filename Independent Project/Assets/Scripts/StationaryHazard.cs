using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryHazard : MonoBehaviour
{
    public int damage;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			//call lose health command?
			//or should I do this detection in player?
		}
	}
}
