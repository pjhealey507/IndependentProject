using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : Character
{
    private InputHandler input;

    // Start is called before the first frame update
    protected override void Start()
    {
        input = new InputHandler();
        base.Start();
    }

	public void Update()
	{
        //this has to be in update because detecting keyup in fixedupdate is inconsistent
        input.GetRewind();
    }


    protected override void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

        base.FixedUpdate();
    }

    protected override void DoCommands()
    {
        Command command = input.GetInput(this);
        command.Execute();
        commands.Push(command);
    }

    public void Shoot()
    {
        GameObject bullet;
        Vector2 mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 player_pos = new Vector2(transform.position.x, transform.position.y);

        bullet = BulletManager.instance.GetBullet();
        if (bullet != null)
        {
            bullet.transform.position = this.transform.position;
            bullet.GetComponent<BulletBehavior>().direction = (mouse_pos - player_pos).normalized;
            bullet.SetActive(true);
        }
    }
}
