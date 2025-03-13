using UnityEngine;

public class FindClosestEnemy : IFindStrategy
{
    public GameObject FindEnemy(Transform player)
    {
        float minDistance = float.MaxValue;
        float currentDistance;
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closestEnemy = null;

        foreach (GameObject enemy in enemys)
        {
            currentDistance = Vector3.Distance(enemy.transform.position, player.transform.position);
            if (minDistance > currentDistance)
            {
                closestEnemy = enemy;
                minDistance = currentDistance;
            }
        }

        return closestEnemy;
    }
}
