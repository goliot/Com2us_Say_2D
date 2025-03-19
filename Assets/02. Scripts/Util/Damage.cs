using System;
using UnityEngine;

public enum DamageType
{
    Bullet,
    Boom,
    Enemy,
}

// 데미지를 추상화
[Serializable]
public struct Damage
{
    public DamageType Type;
    public float Value;
    public GameObject From;
}
