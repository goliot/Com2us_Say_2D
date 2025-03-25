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
                if (_stat.TryUpgrade())
                {
                    PlayerStats.MaxHp += _stat.Value;
                }
                break;
            case EStatType.Damage:
                if (_stat.TryUpgrade())
                {
                    PlayerStats.Damage += _stat.Value;
                }
                break;
            case EStatType.Speed:
                if (_stat.TryUpgrade())
                {
                    PlayerStats.Speed += _stat.Value;
                }
                break;
        }
    }
}
