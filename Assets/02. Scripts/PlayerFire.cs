using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [Header ("# Objects")]
    public GameObject BulletPrefab; // 총알 프리팹
    public GameObject SubBulletPrefab;
    public GameObject[] MuzzlePositions; // 총구
    public GameObject[] SubMuzzlePositions;

    [Header ("# Stats")]
    public float FireCoolTime;
    private float _timeCounter = 0f;

    [Header("# Auto Flag")]
    public bool IsAuto = false;

    private void Update()
    {
        _timeCounter += Time.deltaTime;
        FireModeToggle();
        FireMain();
    }

    private void FireMain()
    {
        if(_timeCounter < FireCoolTime)
        {
            return;
        }

        if ((Input.GetButtonDown("Fire1") && !IsAuto) || IsAuto)
        {
            // 총알을 인스턴스화해 씬에 올리고, 위치를 총구의 위치로 지정
            foreach(GameObject muzzle in MuzzlePositions)
            {
                Instantiate(BulletPrefab, muzzle.transform.position, Quaternion.identity);
            }
            foreach(GameObject muzzle in SubMuzzlePositions)
            {
                Instantiate(SubBulletPrefab, muzzle.transform.position, Quaternion.identity);
            }
            _timeCounter = 0f;
        }
    }

    private void FireModeToggle()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            IsAuto = true;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            IsAuto = false;
        }    
    }
}
