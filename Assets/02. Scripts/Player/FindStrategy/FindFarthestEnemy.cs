using UnityEngine;

public class FindFarthestEnemy : IFindStrategy
{
    public GameObject FindEnemy(Transform playerTransform)
    {
        float maxDistance = 0f;
        GameObject farthestEnemy = null;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(enemy.transform.position, playerTransform.position);
            if (distance > maxDistance)
            {
                maxDistance = distance;
                farthestEnemy = enemy;
            }
        }

        return farthestEnemy;
    }
}
