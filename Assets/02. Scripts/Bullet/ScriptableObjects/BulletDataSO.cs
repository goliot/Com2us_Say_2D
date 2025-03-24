using UnityEngine;

[CreateAssetMenu(fileName = "BulletDataSO", menuName = "Scriptable Objects/BulletDataSO")]
public class BulletDataSO : ScriptableObject
{
    public EObjectType ObjectType;
    public float Speed;
    public float Damage;
}
