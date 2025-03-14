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
            _hp = value;
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
}
