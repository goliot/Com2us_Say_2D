using UnityEngine;

public class Boom : MonoBehaviour
{
    [SerializeField] private float _showTime;
    public Damage _damage;

    private float _timer = 0f;
    public float Timer
    {
        get => _timer;
        set
        {
            _timer = Mathf.Max(0, value);
        }
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _showTime)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().TakeDamage(_damage);
        }
    }
}