using System;
using UnityEngine;

public enum EDamageType
{
    Bullet,
    Boom,
    Enemy,
}

// 데미지를 추상화
[Serializable]
public struct DamageInfo
{
    public EDamageType Type;
    public float Value;
    public GameObject From;
}
