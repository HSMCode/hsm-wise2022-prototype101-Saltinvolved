using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemie : MonoBehaviour

{
    public GameObject[] Decoys;

    // Var for spawn ammount of method
    public int spawnAmount ;

    // Variables for radomizing position
    public float spawnPositionXa = -1f;
    public float spawnPositionXb = 1f;
    public float spawnPositionZa = -1;

    public float spawnPositionZb = 1f;

    // Start is called before the first frame update
    void Start()
    {
        SpawningEnemy(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawningEnemy(int amount)
    {
            for (int i = 0; i < amount; i++)
            {
                int decoysIndex = Random.Range(0,Decoys.Length);

                // generate random spawn position between the defined values
                Vector3 RandomDecoyPosition = new Vector3(Random.Range(-spawnPositionXa, spawnPositionXb),0 ,Random.Range(-spawnPositionZa,spawnPositionZb));

                // instantiate decoy
                Instantiate(Decoys[decoysIndex], RandomDecoyPosition, Quaternion.identity);
            }
    }
}
