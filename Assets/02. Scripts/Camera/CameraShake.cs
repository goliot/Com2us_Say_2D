using UnityEngine;
using DG.Tweening;


public class CameraShake : MonoBehaviour
{
    private Vector3 _originalPosition = new Vector3();

    private void Awake()
    {
        _originalPosition = transform.position;
    }

    public void Shake()
    {
        transform.DOShakePosition(0.1f, 0.2f)
            .OnComplete(() => transform.position = _originalPosition);
    }
}
