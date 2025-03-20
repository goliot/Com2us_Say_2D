using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public Damage DamageInfo;

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
            collision.GetComponent<Player>().TakeDamage(DamageInfo);

            Destroy(gameObject);
        }
    }
}