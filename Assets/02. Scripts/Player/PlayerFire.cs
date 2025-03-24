using NUnit.Framework;
using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class PlayerFire : MonoBehaviour
{
    [Header("# Init")]
    [SerializeField] private float _intialAttackSpeed = 0.6f;

    [Header ("# Objects")]
    public GameObject BulletPrefab; // 총알 프리팹
    public GameObject SubBulletPrefab;
    public GameObject[] MuzzlePositions; // 총구
    public GameObject[] SubMuzzlePositions;

    [Header ("# Timer")]
    private float _timeCounter = 0f;

    public UnityEvent ShootEvent;

    private void Awake()
    {
        PlayerStats.FireCoolTime = _intialAttackSpeed;
    }

    private void Update()
    {
        _timeCounter += Time.deltaTime;
        FireModeToggle();
        FireMain();
    }

    private void FireMain()
    {
        if(_timeCounter < PlayerStats.FireCoolTime || GameManager.Instance.IsFever)
        {
            return;
        }

        if (Input.GetButtonDown("Fire1") || PlayMode.CurrentPlayMode == EPlayMode.Auto)
        {
            ShootEvent.Invoke();

            for (int i = 0; i < MuzzlePositions.Length; i++)
            {
                PoolManager.Instance.Create(EBulletType.MainBullet, MuzzlePositions[i].transform.position);
            }
            for(int i=0; i<SubMuzzlePositions.Length; i++)
            {
                PoolManager.Instance.Create(EBulletType.SubBullet, SubMuzzlePositions[i].transform.position);
            }

            // 총알을 인스턴스화해 씬에 올리고, 위치를 총구의 위치로 지정
            /*foreach(GameObject muzzle in MuzzlePositions)
            {
                List<GameObject> pool = PoolManager.Instance.Bullets;
                foreach(GameObject bullet in pool)
                {
                    if(bullet.GetComponent<Bullet>().BulletType == EBulletType.MainBullet && !bullet.activeSelf)
                    {
                        bullet.transform.position = muzzle.transform.position;
                        bullet.gameObject.SetActive(true);
                        break;
                    }
                }

                //GameObject bullet = Instantiate(BulletPrefab, muzzle.transform.position, Quaternion.identity);
                //bullet.GetComponent<Bullet>().IsLeftBullet = counter % 2 == 0;
            }

            foreach(GameObject muzzle in SubMuzzlePositions)
            {
                List<GameObject> pool = PoolManager.Instance.Bullets;
                foreach (GameObject bullet in pool)
                {
                    if (bullet.GetComponent<Bullet>().BulletType == EBulletType.SubBullet && !bullet.activeSelf)
                    {
                        bullet.transform.position = muzzle.transform.position;
                        bullet.gameObject.SetActive(true);
                        break;
                    }
                }
                //GameObject bullet = Instantiate(SubBulletPrefab, muzzle.transform.position, Quaternion.identity);
            }*/
            _timeCounter = 0f;
        }
    }

    private void FireModeToggle()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlayMode.CurrentPlayMode = EPlayMode.Auto;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            PlayMode.CurrentPlayMode = EPlayMode.Manual;
        }    
    }
}
