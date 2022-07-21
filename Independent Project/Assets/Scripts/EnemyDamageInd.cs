using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageInd : MonoBehaviour
{
    private MaterialPropertyBlock mat_block;
    private Renderer _renderer;
    private Color original_color;
    private Color flash_color;

    public int flash_amount;
    public float flash_time;
    private float current_time;
    private int current_flash_count;
    private bool flashing;

    public void Start()
    {
        mat_block = new MaterialPropertyBlock();
        _renderer = GetComponent<Renderer>();

        original_color = Color.red; 
        flash_color = Color.white;
        current_time = flash_time;
    }

	public void Update()
	{
        if (flashing)
            DecrementTimer();
    }

	private void DecrementTimer()
    {
        current_time -= Time.deltaTime;
        if (current_time <= 0)
        {
            //alternate between original color and flash color
            if (mat_block.GetColor("_Color") == original_color)
                Flash(flash_color);
            else
                Flash(original_color);

            current_time = flash_time;
            current_flash_count++;

            //set back to original color if done flashing
            if (current_flash_count == flash_amount)
            {
                flashing = false;
                Flash(original_color);
            }
        }
    }

    private void Flash(Color color)
    {
        _renderer.GetPropertyBlock(mat_block);
        mat_block.SetColor("_Color", color);
        _renderer.SetPropertyBlock(mat_block);
        

        //_renderer.material.color = Color.white;
        //_renderer.color = Color.black;

        //enemy_mat.SetColor("_Color", Color.white);
        //_renderer.material.color = Color.white;
        /*
        if (enemy_mat.color == original_color)
        {
            enemy_mat.color = Color.white;
        }
        else
        {
            enemy_mat.color = original_color;
        }
        */
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Damaging>() != null)
        {
            flashing = true;
            current_flash_count = 0;
        }
    }
}
