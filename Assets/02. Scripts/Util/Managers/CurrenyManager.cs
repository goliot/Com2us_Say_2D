using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CurrencySaveData
{
    public List<int> Values = new List<int>(new int[(int)ECurrenyType.Count]);
}

public class CurrenyManager : Singleton<CurrenyManager>
{
    private const string SAVE_KEY = "Currency";

    private CurrencySaveData _saveData = new CurrencySaveData();

    public int Gold => _saveData.Values[(int)ECurrenyType.Gold];
    public int Diamond => _saveData.Values[(int)ECurrenyType.Diamond];

    public Action OnCurrencySave;

    private void Awake()
    {
        Load();
    }

    public int Get(ECurrenyType type)
    {
        return _saveData.Values[(int)type];
    }

    public void Add(ECurrenyType type, int value)
    {
        _saveData.Values[(int)type] += value;
        Save();
    }

    public bool TryConsume(ECurrenyType type, int value)
    {
        if (!HaveEnough(type, value))
        {
            return false;
        }
        _saveData.Values[(int)type] -= value;
        Save();
        return true;
    }

    public bool HaveEnough(ECurrenyType type, int value)
    {
        return _saveData.Values[(int)type] >= value;
    }

    private void Save()
    {
        UI_Game.Instance.Refresh();
        OnCurrencySave?.Invoke();
        string jsonData = JsonUtility.ToJson(_saveData);
        PlayerPrefs.SetString(SAVE_KEY, jsonData);
    }

    private void Load()
    {
        //PlayerPrefs.DeleteKey(SAVE_KEY);
        if(PlayerPrefs.HasKey(SAVE_KEY))
        {
            string jsonData = PlayerPrefs.GetString(SAVE_KEY, "null");
            Debug.Log(jsonData);
            _saveData = JsonUtility.FromJson<CurrencySaveData>(jsonData);
        }
        else
        {
            _saveData = new CurrencySaveData();
        }
    }
}