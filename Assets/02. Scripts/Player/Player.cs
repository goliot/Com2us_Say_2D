using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _initialMaxHp;
    [SerializeField] private GameObject DieVFX;

    public UnityEvent DieEvent;

    private void Awake()
    {
        PlayerStats.Hp = PlayerStats.MaxHp = _initialMaxHp;
    }

    public void TakeDamage(DamageInfo damage)
    {
        GameManager.Instance.MainCamera.GetComponent<CameraShake>().Shake();

        if (GameManager.Instance.IsFever)
        {
            return;
        }

        PlayerStats.Hp -= damage.Value;
        Debug.Log($"Hp : {PlayerStats.Hp}");

        if(PlayerStats.Hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Instantiate(DieVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}