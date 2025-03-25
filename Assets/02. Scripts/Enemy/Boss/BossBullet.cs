using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public float Damage;

    [SerializeField]  private EObjectType _objectType;
    public EObjectType ObjectType
    {
        get => _objectType;
    }

    public float Speed;
    public Vector3 Dir;

    private void Update()
    {
        transform.Translate(Dir * Speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().TakeDamage(Damage);

            PoolManager.Instance.ReturnObject(gameObject, ObjectType);
        }
    }
}