using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private GameObject DieEffect;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void Die()
    {
        GameManager.Instance.IsBossSpawned = false;

        Instantiate(DieEffect, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}