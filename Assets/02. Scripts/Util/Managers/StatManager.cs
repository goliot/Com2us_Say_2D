using UnityEngine;
using System.Collections.Generic;

public class StatManager : Singleton<StatManager>
{
    public List<StatDataSO> StatDataList;

    private List<Stat> _stats = new List<Stat>();
    public List<Stat> Stats => _stats;

    public List<UI_StatButton> Buttons;

    private void Awake()
    {
        for (int i = 0; i < (int)EStatType.Count; i++)
        {
            _stats.Add(new Stat(StatDataList[i], (EStatType)i, 1));
        }
    }

    public bool TryLevelUp(EStatType type)
    {
        for (int i = 0; i < (int)EStatType.Count; i++)
        {
            Buttons[i].Refresh();
        }
        return _stats[(int)type].TryUpgrade();
    }
}