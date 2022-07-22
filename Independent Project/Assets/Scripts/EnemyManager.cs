using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Places enemies at the start of the game, uses object pooling

public class EnemyManager : MonoBehaviour
{
    //Singleton
    public static EnemyManager instance { get; private set; }
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
    }

    public GameObject player;
    public GameObject enemy_prefab;
    public List<GameObject> enemies;
    public int pool_count = 20;

    public int enemies_to_start;

    private ParticleSystem particles;

	public void Start()
	{
        particles = GetComponent<ParticleSystem>();

        enemies = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < pool_count; i++)
        {
            tmp = Instantiate(enemy_prefab);
            tmp.GetComponent<Enemy>().player = player;
            tmp.SetActive(false);
            enemies.Add(tmp);
        }

        StartingPlacement();
    }

    public GameObject GetEnemy()
    {
        for (int i = 0; i < pool_count; i++)
        {
            if (!enemies[i].activeInHierarchy)
            {
                RewindManager.instance.AddRewindableObject(enemies[i].GetComponent<RewindableObject>());
                return enemies[i];
            }
        }
        return null;
    }

    public void RemoveEnemy(RewindableObject sender)
    {  
        //particle effect played at the enemy location when it is removed
        particles.transform.position = sender.transform.position;
        particles.Play();

        RewindManager.instance.RemoveRewindableObject(sender);
        sender.gameObject.SetActive(false);
    }

    public void StartingPlacement()
    {
        int max_x = RoomManager.instance.width * RoomManager.instance.room_size;
        int max_y = RoomManager.instance.height * RoomManager.instance.room_size;
        int offset = 10;

        for (int i = 0; i < enemies_to_start; i++)
        {
            //Get enemy from list and place it somewhere in the map
            GameObject enemy = GetEnemy();
            enemy.SetActive(true);
            enemy.transform.position = GetRandomPosition(0, max_x - offset, 0, max_y - offset);
        }
    }

    //Get position value between the parameters
    public Vector3 GetRandomPosition(float min_x, float max_x, float min_y, float max_y)
    {
        Vector3 rand_pos = new Vector3();

        rand_pos.x = Random.Range(min_x, max_x);
        rand_pos.y = Random.Range(min_y, max_y);

        return rand_pos;
    }
}
