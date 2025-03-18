using UnityEngine;
using DG.Tweening;


public class CameraShake : MonoBehaviour
{
    public float ShakeTime;
    public float ShakeStrength;

    private Vector3 _originalPosition = new Vector3();

    private void Awake()
    {
        _originalPosition = transform.position;
    }

    public void Shake()
    {
        transform.DOShakePosition(ShakeTime, ShakeStrength)
            .OnComplete(() => transform.position = _originalPosition);
    }

    public void DieShake()
    {
        ShakeTime = 5;
        Shake();
    }
}
