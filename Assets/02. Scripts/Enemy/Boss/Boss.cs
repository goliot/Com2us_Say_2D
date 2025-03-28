using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Boss : MonoBehaviour
{
    [SerializeField] private GameObject DieEffect;
    [SerializeField] public Vector3 DefaultPosition;
    [SerializeField] private GameObject[] Fires;

    [Header("# Stats")]
    public float MaxHp;
    public float Hp;
    public DamageInfo DamageInfo;
    private float CurrentCoolTime;
    public float NormalCoolTime;
    public float FinchCoolTime;
    public float RageCoolTime;
    private float _timer = 0f;

    public bool IsEntryEnded = false;
    public BossState BossState = BossState.Finch;

    private Coroutine _coFinch = null;
    private Coroutine _coRage = null;
    
    private void Start()
    {
        transform.DOMove(DefaultPosition, 3f).OnComplete(()=>IsEntryEnded = true);
        CurrentCoolTime = NormalCoolTime;
        UI_Game.Instance.BossHpSlider.GetComponent<UI_BossHp>().boss = this;
    }

    void Update()
    {
        if(!IsEntryEnded)
        {
            return;
        }

        _timer += Time.deltaTime;

        switch (BossState)
        {
            case BossState.Normal:
                NormalAttack();
                break;
            case BossState.Finch:
                FinchAttack();
                break;
            case BossState.Rage:
                RageAttack();
                break;
        }
    }

    private void NormalAttack()
    {
        if (_timer < CurrentCoolTime)
        {
            return;
        }

        RoundShot();

        _timer = 0f;
    }

    private void FinchAttack()
    {
        //RoundShot();
        if(_coFinch == null)
        {
            _coFinch = StartCoroutine(CoFinch());
        }
    }

    IEnumerator CoFinch()
    {
        int roundNum = 30;

        for (int idx = 0; idx < roundNum; idx++)
        {
            float angle = Mathf.PI * 2 * idx / roundNum;
            Vector2 dir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            if (dir.y >= 0)
                continue;

            Vector3 rotVec = new Vector3(0, 0, angle * Mathf.Rad2Deg + 90);

            MakeBullet(dir, rotVec);

            yield return new WaitForSeconds(0.1f);
        }
        for(int idx = roundNum; idx >= 0; idx--)
        {
            float angle = Mathf.PI * 2 * idx / roundNum;
            Vector2 dir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            if (dir.y >= 0)
                continue;

            Vector3 rotVec = new Vector3(0, 0, angle * Mathf.Rad2Deg + 90);

            MakeBullet(dir, rotVec);

            yield return new WaitForSeconds(0.1f);
        }

        _timer = 0;
        _coFinch = null;
    }

    private void RageAttack()
    {
        if(_timer < CurrentCoolTime)
        {
            return;
        }

        int selector = UnityEngine.Random.Range(0, 3);
        if(_coRage == null && _coFinch == null)
        {
            if (selector == 0)
                _coRage = StartCoroutine(CoRage());
            else if (selector == 1)
                _coFinch = StartCoroutine(CoFinch());
            else
            {
                _coRage = StartCoroutine(CoRage());
                _coFinch = StartCoroutine(CoFinch());
            }
        }    
    }

    IEnumerator CoRage()
    {
        int roundNum = 30;

        for (int idx = 0; idx < roundNum; idx++)
        {
            float baseAngle = Mathf.PI * 2 * idx / roundNum;
            for (int j=0; j<4; j++)
            {
                float angle = baseAngle + j * Mathf.PI / 2;
                Vector2 dir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
                Vector3 rotVec = new Vector3(0, 0, angle * Mathf.Rad2Deg + 90);

                MakeBullet(dir, rotVec);
            }
            yield return new WaitForSeconds(0.1f);
        }

        _timer = 0;
        _coRage = null;
    }

    private void CheckBossState()
    {
        if(Hp > MaxHp * 0.7f)
        {
            BossState = BossState.Normal;
            CurrentCoolTime = NormalCoolTime;
        }
        else if(Hp > MaxHp * 0.3f)
        {
            BossState = BossState.Finch;
            CurrentCoolTime = FinchCoolTime;
            Fires[0].SetActive(true);
        }
        else
        {
            BossState = BossState.Rage;
            CurrentCoolTime = RageCoolTime;
            Fires[1].SetActive(true);
            Fires[2].SetActive(true);
        }
    }

    private void RoundShot()
    {
        int roundNum = 30;
        for (int idx = 0; idx < roundNum; idx++)
        {
            Vector2 dir = new Vector2(Mathf.Cos(Mathf.PI * 2 * idx / roundNum),
                                      Mathf.Sin(Mathf.PI * 2 * idx / roundNum));
            Vector3 rotVec = Vector3.forward * 360 * idx / roundNum + Vector3.forward * 90;

            MakeBullet(dir, rotVec);
        }
    }

    private void MakeBullet(Vector2 dir, Vector3 rotVec)
    {
        BossBullet bullet = PoolManager.Instance.GetObject(EObjectType.BossBullet).GetComponent<BossBullet>();
        bullet.transform.rotation = Quaternion.Euler(rotVec);
        bullet.transform.position = transform.position;
        bullet.Dir = dir.normalized;
    }

    public void TakeDamage(float damage)
    {
        Hp -= damage;

        transform.DOShakeScale(0.1f, 0.05f).OnComplete(() => transform.localScale = Vector3.one);

        CheckBossState();

        UI_Game.Instance.BossHpSlider.GetComponent<UI_BossHp>().ShakeSlider();


        if (Hp <= 0)
            Die();
    }

    private void Die()
    {
        GameManager.Instance.IsBossSpawned = false;
        UI_Game.Instance.BossHpSlider.gameObject.SetActive(false);
        PlayerStats.Score += 10000;
        Instantiate(DieEffect, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}