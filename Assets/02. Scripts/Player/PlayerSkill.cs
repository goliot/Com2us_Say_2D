using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    [SerializeField] private int _boomCount = 0;
    [SerializeField] private int _boomMaxCount = 3;
    [SerializeField] private GameObject _boomObject;

    [SerializeField] private int _addBoomKillAmount = 20;

    private void Update()
    {
        BoomCount();
        MakeBoom();
    }

    private void BoomCount()
    {
        if (PlayerStats.KillCount >= _addBoomKillAmount)
        {
            PlayerStats.KillCount -= _addBoomKillAmount;
            _boomCount = Mathf.Min(_boomMaxCount, _boomCount + 1);
        }
    }

    private void MakeBoom()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3) && _boomCount > 0)
        {
            ActiveBoom();
        }
    }

    private void ActiveBoom()
    {
        _boomCount--;
        _boomObject.SetActive(true);
        _boomObject.GetComponent<Boom>().Timer = 0;
    }
}
