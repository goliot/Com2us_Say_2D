using TMPro;
using UnityEngine;

public class UI_StatButton : MonoBehaviour
{
    public Stat _stat;

    public TextMeshProUGUI NameTextUI;
    public TextMeshProUGUI ValueTextUI;
    public TextMeshProUGUI CostTextUI;

    private void Start()
    {
        
        Refresh();
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
                    PlayerStats.Damage += _stat.Value;
                }
                break;
            case EStatType.Speed:
                if (StatManager.Instance.TryLevelUp(_stat.StatType))
                {
                    PlayerStats.Speed += _stat.Value;
                }
                break;
        }
    }
}
