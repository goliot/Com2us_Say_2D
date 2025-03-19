using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    [SerializeField] private GameObject _boomObject;

    [SerializeField] private int _addBoomKillAmount = 20;

    private int _lastCount = 0;

    private void Update()
    {
        BoomCount();
        MakeBoom();
    }

    private void BoomCount()
    {
        if (PlayerStats.KillCount >= _lastCount +_addBoomKillAmount)
        {
            _lastCount = PlayerStats.KillCount;
            PlayerStats.BoomCount++;
        }
    }

    private void MakeBoom()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3) && PlayerStats.BoomCount > 0)
        {
            ActiveBoom();
        }
    }

    private void ActiveBoom()
    {
        PlayerStats.BoomCount--;
        _boomObject.SetActive(true);
        _boomObject.GetComponent<Boom>().Timer = 0;
    }
}
