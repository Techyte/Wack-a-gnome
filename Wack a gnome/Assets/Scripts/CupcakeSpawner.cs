using UnityEngine;
using Random = UnityEngine.Random;

public class CupcakeSpawner : MonoBehaviour
{
    private float _timeTillNextSpawn = 0;

    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private Cupcake cupcakePreset;
    [SerializeField] private Cupcake infectedCupcakePreset;
    [SerializeField] private float speed;
    [SerializeField] private AnimationCurve spawnRates;
    
    private void Update()
    {
        _timeTillNextSpawn -= Time.deltaTime;

        if (_timeTillNextSpawn <= 0)
        {
            int spawnPoint = Random.Range(0, spawnPoints.Length);

            Cupcake newCupcake;
            if (Time.realtimeSinceStartup < 15)
            {
                newCupcake = Instantiate(cupcakePreset, spawnPoints[spawnPoint].position, Quaternion.identity);   
            }
            else
            {
                if (Random.Range(0,20) == 0)
                {
                    newCupcake = Instantiate(infectedCupcakePreset, spawnPoints[spawnPoint].position, Quaternion.identity);
                }
                else
                {
                    newCupcake = Instantiate(cupcakePreset, spawnPoints[spawnPoint].position, Quaternion.identity);   
                }
            }

            if (spawnPoint > 3)
            {
                newCupcake.Init(-speed);
            }
            else
            {
                newCupcake.Init(speed);
            }

            _timeTillNextSpawn = Mathf.Clamp(-(1f / 120f) * Time.realtimeSinceStartup + 5, 2, 100000);
        }
    }
}
