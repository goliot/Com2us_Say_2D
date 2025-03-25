using UnityEngine;
using System.Collections.Generic;

public class StatManager : Singleton<StatManager>
{
    public List<StatDataSO> StatDataList;

    private List<Stat> _stats = new List<Stat>();
    public List<Stat> Stats => _stats;

    private void Awake()
    {
        for (int i = 0; i < (int)EStatType.Count; i++)
        {
            _stats.Add(new Stat(StatDataList[i], (EStatType)i, 1));
        }
    }

    public bool TryLevelUp(EStatType type)
    {
        return _stats[(int)type].TryUpgrade();
    }
}