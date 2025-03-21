using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerSkill : MonoBehaviour
{
    [SerializeField] private GameObject _boomObject;
    [SerializeField] public GameObject[] FeverEffects;
    [SerializeField] private int _addBoomKillAmount = 20;

    private int _lastCount = 0;

    private void Update()
    {
        BoomCount();
        MakeBoom();
        ActiveFever();
        if (EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log("UI 클릭 중! 키 입력 무시");
            return; // UI 클릭 상태면 입력 무시
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("Z 키 입력!");
        }
    }

    private void ActiveFever()
    {
        if(Input.GetKeyDown(KeyCode.Z) && !GameManager.Instance.IsFever && !GameManager.Instance.IsBossSpawned)
        {
            Debug.Log("Z");
            StartCoroutine(GameManager.Instance.CoFever());
        }
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
