using UnityEngine;

public class Boom : MonoBehaviour
{
    private float _timer = 0f;

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > 2f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().TakeDamage(float.MaxValue);
        }
    }
}