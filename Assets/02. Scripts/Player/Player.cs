using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _initialMaxHp;
    
    private void Awake()
    {
        PlayerStats.Hp = PlayerStats.MaxHp = _initialMaxHp;
    }

    public void TakeDamage(Damage damage)
    {
        PlayerStats.Hp -= damage.Value;
        Debug.Log($"Hp : {PlayerStats.Hp}");
        GameManager.Instance.MainCamera.GetComponent<CameraShake>().Shake();

        if(PlayerStats.Hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}