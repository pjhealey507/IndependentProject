using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//stays a certain distance from the player, moves in circles around the player
public class Enemy : Character
{
    //enemy stays a certain distance away
    public float max_distance;
    public float min_distance;
    public float cur_distance;

    //enemy revolves clockwise or counterclockwise around the player
    public bool clockwise;
    public GameObject player;

    //movement direction
    private Vector3 direction;

    //shooting stuff
    float shoot_timer = 2;
    float cur_shoot_timer;

	protected override void Start()
	{
        player = FindObjectOfType<PlayerControl>().gameObject;
        cur_shoot_timer = shoot_timer;
		base.Start();
	}

	protected override void FixedUpdate()
	{
        DetermineDirection();
        DecrementTimer();
		base.FixedUpdate();
	}

	protected override void DoCommands()
	{
        Command command;

        //in sweet spot
        if (cur_distance < max_distance && cur_distance > min_distance)
        {
            command = new Stop(this);
        }
        else
        {
            command = new Move(this, direction);
        }

        command.Execute();
        commands.Push(command);
	}

    void DetermineDirection()
    {
        cur_distance = Vector3.Distance(player.transform.position, this.transform.position);

        //player is too close
        if (cur_distance < min_distance)
        {
            //move away from player
            direction = -(player.transform.position - this.transform.position);
        }

        //player is too far
        if (cur_distance > max_distance)
        {
            //move towards player
            direction = (player.transform.position - this.transform.position);
        }

        direction = direction.normalized;
    }

    public Vector3 GetShootDirection()
    {
        return player.transform.position - this.transform.position;
    }

    public void Shoot(Vector3 direction)
    {
        GameObject bullet;

        bullet = BulletManager.instance.GetEnemyBullet();
        if (bullet != null)
        {
            bullet.transform.position = this.transform.position;
            bullet.GetComponent<BulletBehavior>().direction = direction.normalized;
            bullet.SetActive(true);
        }
    }

    public void DecrementTimer()
    {
        cur_shoot_timer -= Time.deltaTime;

        if (cur_shoot_timer <= 0)
        {
            Shoot(GetShootDirection());
            cur_shoot_timer = shoot_timer;
        }
    }

	public override void Die()
	{
        EnemyManager.instance.RemoveEnemy(this);

        base.Die();
	}
}