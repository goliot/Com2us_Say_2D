using UnityEngine;

public class Boom : MonoBehaviour
{
    [SerializeField] private float _showTime;
    [SerializeField] private DamageInfo _damage;

    private float _timer = 0f;
    public float Timer
    {
        get => _timer;
        set
        {
            _timer = Mathf.Max(0, value);
        }
    }

    private void Awake()
    {
        _damage.Value = float.MaxValue;
        _damage.From = gameObject;
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _showTime)
        {
            gameObject.SetActive(false);
            _timer = 0;
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