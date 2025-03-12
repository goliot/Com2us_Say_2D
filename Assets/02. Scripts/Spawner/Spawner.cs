using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] Enemys;

    [Header ("# Spawning")]
    [SerializeField] private Transform[] SpawnPoints;
    [SerializeField] private float[] SpawnRates;
    [SerializeField][Range(2, 4)] private float MaxSpawnCooltime;
    [SerializeField][Range(0.1f, 1f)] private float MinSpawnCooltime;
   
    private float _timer = 0f;
    private float _nextSpawnCooltime;

    private void Awake()
    {
        float rateSum = SpawnRates.Sum();
        for(int i=0; i<SpawnRates.Length; i++)
        {
            SpawnRates[i] = (SpawnRates[i] / rateSum) * 100;
            if (i > 0)
            {
                SpawnRates[i] += SpawnRates[i - 1];
            }
        }

        _nextSpawnCooltime = Random.Range(MinSpawnCooltime, MaxSpawnCooltime);
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > _nextSpawnCooltime)
        {
            Spawn(SpawnPoints[Random.Range(0, SpawnPoints.Length)]);
            _nextSpawnCooltime = Random.Range(MinSpawnCooltime, MaxSpawnCooltime);
            _timer = 0f;
        }
    }

    private void Spawn(Transform spawnPoint)
    {
        float randNum = Random.Range(0f, 100f);

        for(int i=0; i<SpawnRates.Length; i++)
        {
            if(randNum < SpawnRates[i])
            {
                Instantiate(Enemys[i], spawnPoint.position, Quaternion.identity);
                return;
            }
        }
        Instantiate(Enemys[SpawnRates.Length - 1], spawnPoint.position, Quaternion.identity);
    }
}