using UnityEngine;

public class SubBullet : Bullet
{
    private void Start()
    {
        BulletType = BulletType.SubBullet;
    }

    /*public override void Movement()
    {
        _lerpTime += Time.deltaTime;
        if (_lerpTime > 2 * Mathf.PI)
        {
            _lerpTime = 0f;
        }

        float h = Mathf.Cos(Frequency * _lerpTime);
        
        _direction = new Vector3(h, 1, 0).normalized;
        transform.Translate(h * Speed * Time.deltaTime, Speed * Time.deltaTime, 0);
    }*/
}
