using UnityEngine;

public class TargetEnemy : Enemy
{
    private void OnEnable()
    {
        _direction = Vector3.Normalize(TargetPlayer.position - transform.position);
    }

    private void Update()
    {
        TargetMovement();
    }

    private void TargetMovement()
    {
        transform.Translate(_direction * Speed * Time.deltaTime);
    }
}
