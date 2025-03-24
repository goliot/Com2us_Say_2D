using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private static LevelManager _instance;
    public static LevelManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<LevelManager>();
            }
            return _instance;
        }
    }

    [SerializeField] private List<LevelDataSO> _levelDatas;

    public LevelDataSO GetLevelData()
    {
        int score = PlayerStats.Score;

        foreach(LevelDataSO data in _levelDatas)
        {
            if(data.Score < score)
            {
                return data;
            }
        }

        return _levelDatas[^1];
    }
}