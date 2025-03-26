using Coffee.UIEffects;
using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;

public class UI_StatButton : MonoBehaviour
{
    public Stat _stat;

    public TextMeshProUGUI NameTextUI;
    public TextMeshProUGUI ValueTextUI;
    public TextMeshProUGUI CostTextUI;

    [Header("Click Effect")]
    public ParticleSystem ClickParticle;
    private bool _isClickHold = false;
    private Coroutine _coClickHold;
    public UIEffect _uiEffect;

    private void Awake()
    {
        //ClickParticle.Stop();
        _uiEffect = GetComponent<UIEffect>();
    }

    public void Refresh()
    {
        NameTextUI.text = _stat.StatType.ToString();
        ValueTextUI.text = _stat.Value.ToString();
        CostTextUI.text = _stat.Cost.ToString();
    }

    public void OnClick()
    {
        switch(_stat.StatType)
        {
            case EStatType.Health:
                if (StatManager.Instance.TryLevelUp(_stat.StatType))
                {
                    Debug.Log("Before" + PlayerStats.MaxHp);
                    PlayerStats.MaxHp += _stat.Value;
                    Debug.Log("After" + PlayerStats.MaxHp);
                }
                break;
            case EStatType.Damage:
                if (StatManager.Instance.TryLevelUp(_stat.StatType))
                {
                    Debug.Log("Before" + PlayerStats.Damage);
                    PlayerStats.Damage += _stat.Value;
                    Debug.Log("After" + PlayerStats.Damage);
                }
                break;
            case EStatType.Speed:
                if (StatManager.Instance.TryLevelUp(_stat.StatType))
                {
                    Debug.Log("Before" + PlayerStats.Speed);
                    PlayerStats.Speed += _stat.Value;
                    Debug.Log("After" + PlayerStats.Speed);
                }
                break;
        }
    }

    public void OnClickHold()
    {
        if(_coClickHold == null)
        {
            _coClickHold = StartCoroutine(CoClickHold());
        }
    }

    public void OnClickUp()
    {
        //ClickParticle.Stop();
        //ClickParticle.Clear();
        //ClickParticle.Play();

        _isClickHold = false;
    }

    IEnumerator CoClickHold()
    {
        _isClickHold = true;
        transform.DOScale(0.9f, 0.2f).SetEase(Ease.Linear).OnComplete(()=>transform.localScale = new Vector3(0.9f, 0.9f, 0.9f));

        while(_isClickHold)
        {
            yield return null;
        }

        transform.DOScale(1, 0.2f).SetEase(Ease.InOutSine);
        _coClickHold = null;
    }
}