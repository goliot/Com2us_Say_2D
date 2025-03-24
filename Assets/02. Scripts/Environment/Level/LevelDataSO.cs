using UnityEngine;

[CreateAssetMenu(fileName = "LevelDataSO", menuName = "Scriptable Objects/LevelDataSO")]
public class LevelDataSO : ScriptableObject
{
    public int Score;                 // 기준이 되는 점수
    public float DamageFactor = 1;    // 곱해 줄 계수
    public float HealthFactor = 1;
    public float SpeedFactor = 1;
}
