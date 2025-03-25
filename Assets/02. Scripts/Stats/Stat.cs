using System.Collections.Generic;
using UnityEngine;

public class Stat
{
    private EStatType StatType;
    private int Level;

    private StatDataSO _data;

    private float Value;
    private int Cost;

    public Stat(StatDataSO data, EStatType statType, int level)
    {
        _data = data;
        StatType = statType;
        Level = level;

        Calculate();
    }

    public bool TryUpgrade()
    {
        if(!CurrenyManager.Instance.TryConsume(ECurrenyType.Gold, Cost))
        {
            return false;
        }

        Level++;
        Calculate();
        return true;
    }

    private void Calculate()
    {
        Value = _data.DefaultValue + Level * _data.UpgradeAddValue;
        Cost = (int)(_data.DefaultCost + Level * _data.UpgradeAddCost);
    }
}
