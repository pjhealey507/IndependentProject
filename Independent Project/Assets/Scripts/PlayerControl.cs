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

        //move this somewhere else
        hp_text.text = hp.ToString();
    }


    protected override void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot(GetMousePosition());
        }

        base.FixedUpdate();
    }

    protected override void DoCommands()
    {
        Command command = input.GetInput(this);
        command.Execute();
        commands.Push(command);
    }

    public Vector3 GetMousePosition()
    {
        Vector2 mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 player_pos = new Vector2(transform.position.x, transform.position.y);

        return (mouse_pos - player_pos);
    }

    public void Shoot(Vector3 direction)
    {
        GameObject bullet;

        bullet = BulletManager.instance.GetBullet();
        if (bullet != null)
        {
            bullet.transform.position = this.transform.position;
            bullet.GetComponent<BulletBehavior>().direction = direction.normalized;
            bullet.SetActive(true);
        }
    }
}
