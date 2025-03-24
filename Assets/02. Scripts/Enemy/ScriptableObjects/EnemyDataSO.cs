using UnityEngine;

[CreateAssetMenu(fileName = "EnemyDataSO", menuName = "Scriptable Objects/EnemyDataSO")]
public class EnemyDataSO : ScriptableObject
{
    public EObjectType ObjectType;
    public float MaxHp;
    public float Damage;
    public int Score;
    public float Speed;
}
