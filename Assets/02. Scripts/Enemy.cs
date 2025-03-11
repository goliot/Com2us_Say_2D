using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header ("# Movement")]
    public float Speed = 5f;
    private Vector3 _direction = new Vector3();
    public float CurveIntensity = 2f;

    [Header("# Info")]
    public EnemyType EnemyType;
    public int Hp = 2;
    private bool IsDead = false;

    [Header("# Skill")]
    public GameObject SubEnemy;
    public Transform TargetPlayer;

    private void Update()
    {
        Movement();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            BulletType type = collision.GetComponent<Bullet>().BulletType;
            if (type == BulletType.MainBullet)
            {
                Die();
            }
            else if(type == BulletType.SubBullet)
            {
                Hp--;
                if(Hp <= 0)
                {
                    Die();
                }
            }

            Destroy(collision.gameObject);
        }
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerStats>().TakeDamage();
            Die();
        }
    }

    protected virtual void Movement()
    {
        if (EnemyType == EnemyType.Common || EnemyType == EnemyType.Split)
        {
            _direction = Vector3.down;
            transform.Translate(_direction * Speed * Time.deltaTime);
        }
        else if (EnemyType == EnemyType.Sub)
        {
            // TODO : 베지어 곡선으로 추적
            BezierChase();
        }
    }

    private void Split()
    {
        for(int i=0; i<3; i++)
        {
            GameObject sub = Instantiate(SubEnemy, new Vector3(transform.position.x + (i - 1f) * 0.5f, transform.position.y, transform.position.z), Quaternion.identity);
            sub.GetComponent<Enemy>().TargetPlayer = GameObject.FindGameObjectWithTag("Player").transform;
            sub.GetComponent<Enemy>().EnemyType = EnemyType.Sub;
        }
    }

    private void BezierChase()
    {

    }

    private void Die()
    {
        if (IsDead) return;
        IsDead = true;

        if (EnemyType == EnemyType.Split)
        {
            Split();
        }
        Destroy(gameObject);
    }
}
