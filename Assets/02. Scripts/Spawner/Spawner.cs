using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] Enemys;
    [SerializeField] private GameObject Boss;

    [Header ("# Spawning")]
    [SerializeField] private Transform[] SpawnPoints;
    [SerializeField] private Transform BossSpawnPoint;
    [SerializeField] private float[] SpawnRates;
    [SerializeField][Range(1, 4)] private float MaxSpawnCooltime;
    [SerializeField][Range(0.1f, 1f)] private float MinSpawnCooltime;
   
    private float _timer = 0f;
    private float _nextSpawnCooltime;

    private float _leftBorder;
    private float _rightBorder;

    private void Awake()
    {
        float rateSum = SpawnRates.Sum();
        for(int i=0; i<SpawnRates.Length; i++)
        {
            SpawnRates[i] = SpawnRates[i] / rateSum;
            if (i > 0)
            {
                SpawnRates[i] += SpawnRates[i - 1];
            }
        }

        _nextSpawnCooltime = Random.Range(MinSpawnCooltime, MaxSpawnCooltime);

        _leftBorder = Camera.main.transform.position.x - Camera.main.orthographicSize * Camera.main.aspect;
        _rightBorder = Camera.main.transform.position.x + Camera.main.orthographicSize * Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > _nextSpawnCooltime && PlayerStats.KillCount < 100)
        {
            SpawnRoutine();
        }

        if(PlayerStats.KillCount >= 100 && !GameManager.Instance.IsBossSpawned)
        {
            SpawnBoss();
        }
    }

    private void SpawnRoutine()
    {
        Enemy enemy = Spawn(Random.Range(0, SpawnPoints.Length)).GetComponent<Enemy>();
        if (enemy.EnemyType == EEnemyType.Basic || enemy.EnemyType == EEnemyType.Split)
        {
            if (enemy.transform.position.x < _leftBorder)
            {
                enemy.Direction = Vector3.right;
            }
            else if (enemy.transform.position.x > _rightBorder)
            {
                enemy.Direction = Vector3.left;
            }
            else
            {
                enemy.Direction = Vector3.down;
            }
        }

        _nextSpawnCooltime = Random.Range(MinSpawnCooltime, MaxSpawnCooltime);
        _timer = 0f;
    }

    private GameObject Spawn(int spawnPointIndex)
    {
        float randNum = Random.value;

        for(int i=0; i<SpawnRates.Length; i++)
        {
            if(randNum < SpawnRates[i])
            {
                return Instantiate(Enemys[i], SpawnPoints[spawnPointIndex].position, Quaternion.identity);
                
            }
        }
        return Instantiate(Enemys[SpawnRates.Length - 1], SpawnPoints[spawnPointIndex].position, Quaternion.identity);
    }
    
    public void SpawnBoss()
    {
        GameManager.Instance.IsBossSpawned = true;

        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in Enemies)
        {
            enemy.GetComponent<Enemy>().BossSpawnClear();
        }

        Instantiate(Boss, BossSpawnPoint.position, Quaternion.identity);
    }
}