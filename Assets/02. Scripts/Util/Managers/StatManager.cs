using UnityEngine;
using System.Collections.Generic;
using System;

public class StatManager : Singleton<StatManager>
{
    public List<StatDataSO> StatDataList;

    private List<Stat> _stats = new List<Stat>();
    public List<Stat> Stats => _stats;

    public Action OnDataChangedCallback = null;

    private void Awake()
    {
        for (int i = 0; i < (int)EStatType.Count; i++)
        {
            _stats.Add(new Stat(StatDataList[i], (EStatType)i, 0));
        }
    }

    public bool TryLevelUp(EStatType type)
    {
        if(_stats[(int)type].TryUpgrade())
        {
            OnDataChangedCallback?.Invoke();
            return true;
        }
        return false;
    }
}