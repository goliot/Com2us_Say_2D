using Coffee.UIEffects;
using Coffee.UIExtensions;
using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_StatButton : UI_TouchBounce
{
    public Stat _stat;

    public TextMeshProUGUI NameTextUI;
    public TextMeshProUGUI ValueTextUI;
    public TextMeshProUGUI CostTextUI;

    private void Awake()
    {
        //ClickParticle.Stop();
        UiEffect = GetComponent<UIEffect>();
    }

    public void Refresh()
    {
        NameTextUI.text = _stat.StatType.ToString();
        ValueTextUI.text = _stat.Value.ToString();
        CostTextUI.text = _stat.Cost.ToString();
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);

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
}