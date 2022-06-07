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
    public GameObject bullet_prefab;

    //how many are created
    int pool_count = 100;

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
    }

    // Update is called once per frame
    void Update()
    {

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

    public void RemoveBullet(RewindableObject sender)
    {
        RewindManager.instance.RemoveRewindableObject(sender);
        sender.gameObject.SetActive(false);
    }
}
