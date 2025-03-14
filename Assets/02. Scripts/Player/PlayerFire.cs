using UnityEngine;

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
        if(_timeCounter < PlayerStats.FireCoolTime)
        {
            return;
        }

        if (Input.GetButtonDown("Fire1") || PlayMode.CurrentPlayMode == EPlayMode.Auto)
        {
            int counter = 0;
            // 총알을 인스턴스화해 씬에 올리고, 위치를 총구의 위치로 지정
            foreach(GameObject muzzle in MuzzlePositions)
            {
                GameObject bullet = Instantiate(BulletPrefab, muzzle.transform.position, Quaternion.identity);
                bullet.GetComponent<Bullet>().IsLeftBullet = counter % 2 == 0;
                counter++;
            }

            foreach(GameObject muzzle in SubMuzzlePositions)
            {
                GameObject bullet = Instantiate(SubBulletPrefab, muzzle.transform.position, Quaternion.identity);
            }
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
