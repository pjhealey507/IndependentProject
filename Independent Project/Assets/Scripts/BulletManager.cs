using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Manages creation of bullets via object pooling

public class BulletManager : MonoBehaviour
{
    //Singleton
    public static BulletManager instance { get; private set; }
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

    public List<GameObject> bullets;
    public List<GameObject> enemy_bullets;
    public GameObject bullet_prefab;
    public GameObject enemy_bullet_prefab;

    //how many are created
    public int pool_count = 50;
    public int enemy_pool_count = 50;

    // Start is called before the first frame update
    void Start()
    {
        bullets = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < pool_count; i++)
        {
            tmp = Instantiate(bullet_prefab);
            tmp.SetActive(false);
            bullets.Add(tmp);
        }
        for (int i = 0; i < enemy_pool_count; i++)
        {
            tmp = Instantiate(enemy_bullet_prefab);
            tmp.SetActive(false);
            enemy_bullets.Add(tmp);
        }
    }

    //return the earliest non-active bullet in the list
    public GameObject GetBullet()
    {
        for (int i = 0; i < pool_count; i++)
        {
            if (!bullets[i].activeInHierarchy)
            {
                return bullets[i];
            }
        }
        return null;
    }

    //return the earliest non-active enemy bullet in the list
    public GameObject GetEnemyBullet()
    {
        for (int i = 0; i < enemy_pool_count; i++)
        {
            if (!enemy_bullets[i].activeInHierarchy)
            {
                return enemy_bullets[i];
            }
        }
        return null;
    }

    public void RemoveBullet(RewindableObject sender)
    {
        RewindManager.instance.RemoveRewindableObject(sender);
        sender.gameObject.SetActive(false);
    }
}
