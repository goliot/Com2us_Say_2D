using System;
using System.Collections.Generic;
using UnityEngine;

public enum CurrenyType
{
    Gold,
    Diamond,
    Count,
}

[Serializable]
public class CurrencySaveData
{
    public List<int> Values = new List<int>(new int[(int)CurrenyType.Count]);
}

public class CurrenyManager : MonoBehaviour
{
    private static CurrenyManager _instance;
    public static CurrenyManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<CurrenyManager>();
            }
            return _instance;
        }
    }

    private const string SAVE_KEY = "Currency";

    private CurrencySaveData _saveData = new CurrencySaveData();

    public int Gold => _saveData.Values[(int)CurrenyType.Gold];
    public int Diamond => _saveData.Values[(int)CurrenyType.Diamond];

    private void Awake()
    {
        Load();
    }

    public int Get(CurrenyType type)
    {
        return _saveData.Values[(int)type];
    }

    public void Add(CurrenyType type, int value)
    {
        _saveData.Values[(int)type] += value;
        Save();
    }

    public bool TryConsume(CurrenyType type, int value)
    {
        if (!HaveEnough(type, value))
        {
            return false;
        }
        _saveData.Values[(int)type] -= value;
        Save();
        return true;
    }

    public bool HaveEnough(CurrenyType type, int value)
    {
        return _saveData.Values[(int)type] >= value;
    }

    private void Save()
    {
        UI_Game.Instance.RefreshGold();
        string jsonData = JsonUtility.ToJson(_saveData);
        PlayerPrefs.SetString(SAVE_KEY, jsonData);
    }

    private void Load()
    {
        //PlayerPrefs.DeleteKey(SAVE_KEY);
        if(PlayerPrefs.HasKey(SAVE_KEY))
        {
            string jsonData = PlayerPrefs.GetString(SAVE_KEY, "null");
            _saveData = JsonUtility.FromJson<CurrencySaveData>(jsonData);
        }
        else
        {
            _saveData = new CurrencySaveData();
        }
    }
}