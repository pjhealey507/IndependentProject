using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
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

    public void CreateEnemy()
    {
        GameObject enemy = Instantiate(enemy_prefab);
        enemy.GetComponent<Enemy>().player = player;
    }
}
