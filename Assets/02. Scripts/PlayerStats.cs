using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float Hp = 3;

    public void TakeDamage()
    {
        Hp--;
        if(Hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
