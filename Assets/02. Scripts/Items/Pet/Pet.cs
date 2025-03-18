using TMPro;
using UnityEngine;

public class Pet : MonoBehaviour
{
    [Header("# Pos")]
    [SerializeField] private Transform Muzzle;
    [SerializeField] private Transform TargetPosition;

    [Header("# Bullet")]
    [SerializeField] private GameObject Bullet;

    [Header("# Movement")]
    [SerializeField] private float _smoothTime = 0.3f;
    private Vector3 _velocity = Vector3.zero;

    private void LateUpdate()
    {
        if (TargetPosition == null)
            return;

        Follow();
    }

    public void Shoot()
    {
        Instantiate(Bullet, Muzzle.position, Quaternion.identity);
    }

    private void Follow()
    {
        transform.position = Vector3.SmoothDamp(transform.position, TargetPosition.position, ref _velocity, _smoothTime);
    }
}
