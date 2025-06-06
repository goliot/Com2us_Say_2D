using UnityEngine;
using System.Collections.Generic;

public class BulletPool : MonoBehaviour
{
    public static BulletPool _instance;
    public static BulletPool Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<BulletPool>();
            }
            return _instance;
        }
    }

    public int PoolSize;
    public List<GameObject> BulletPrefabs;
    private List<GameObject> _bullets = new List<GameObject>();
    public List<GameObject> Bullets
    {
        get => _bullets;
    }

    private void Awake()
    {
        int bulletPrefabCount = BulletPrefabs.Count;

        foreach(GameObject bulletPrefab in BulletPrefabs)
        {
            for(int i=0; i<PoolSize; i++)
            {
                GameObject bullet = Instantiate(bulletPrefab, transform);
                _bullets.Add(bullet);
                bullet.SetActive(false);
            }
        }
    }

    /*public GameObject CreateBullet(EBulletType bulletType, Vector3 position)
    {
        foreach (GameObject bullet in _bullets)
        {
            if (bullet.GetComponent<Bullet>().BulletType == bulletType && !bullet.activeSelf)
            {
                bullet.transform.position = position;
                bullet.gameObject.SetActive(true);
                return bullet;
            }
        }

        return null;
    }*/

    public void Release(GameObject target)
    {
        target.SetActive(false);
    }
}