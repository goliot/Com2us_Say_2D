using UnityEngine;

public static class PlayerStats
{
    private static float _maxHp = 10000;
    public static float MaxHp
    {
        get => _maxHp;
        set
        {
            _maxHp = value;
        }
    }

    private static float _hp = 100;
    public static float Hp
    {
        get => _hp;
        set
        {
            _hp = Mathf.Min(value, _maxHp);
        }
    }

    private static float _fireCoolTime = 0.6f;
    public static float FireCoolTime
    {
        get => _fireCoolTime;
        set
        {
            _fireCoolTime = Mathf.Max(0.2f, value);
        }
    }

    public static float MaxSpeed = 10f;
    public static float MinSpeed = 1f;
    private static float _speed = 3f;
    public static float Speed
    {
        get => _speed;
        set
        {
            _speed = Mathf.Clamp(value, MinSpeed, MaxSpeed);
        }
    }

    private static int _killCount = 0;
    public static int KillCount
    {
        get => _killCount;
        set
        {
            _killCount = value;
            UI_Game.Instance.Refresh();
        }
    }

    private static int _boomCount = 0;
    public static int BoomCount
    {
        get => _boomCount;
        set
        {
            _boomCount = Mathf.Clamp(value, 0, 3);
            UI_Game.Instance.Refresh();
        }
    }

    private static int _score = 0;
    public static int Score
    {
        get => _score;
        set
        {
            _score = value;
            UI_Game.Instance.Refresh();
            //Save();
        }
    }

    /*public static void Save()
    {
        PlayerPrefs.SetInt("Score", _score);
    }

    public static void Load()
    {
        _score = PlayerPrefs.GetInt("Score", 0);
        GameManager.Instance.UI.Refresh();
    }*/
}
