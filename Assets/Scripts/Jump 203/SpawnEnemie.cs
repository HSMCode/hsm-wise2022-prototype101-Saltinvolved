using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemie : MonoBehaviour

{
   public  GameObject Enemy;
    public GameObject[] Enemys;

    // Var for spawn ammount of method
    public int spawnAmount = 5;

    // Variables for radomizing position
    public float spawnPositionXa = -20f;
    public float spawnPositionXb = 20f;
    public float spawnPositionZa = -20;

    public float spawnPositionZb = 20f;

    /// Variables Invoke Repeating
    public float startDelay= 5f;
    public float spawnInterwal = 50f;

    // Start is called before the first frame update
    void Start()
    {
        SpawningEnemyParam(spawnAmount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // void SpawningEnemy()
    // {
    //         for (int i = 0; i < 5; i++)
    //         {
    //             int enemysIndex = Random.Range(0,Enemys.Length);

    //             // generate random spawn position between the defined values
    //             Vector3 spawnPosition = new Vector3(Random.Range(-spawnPositionXa, spawnPositionXb),0 ,Random.Range(-spawnPositionZa,spawnPositionZb));

    //             // instantiate decoy
    //             Instantiate(Enemys[enemysIndex],spawnPosition,Enemys[enemysIndex].transfom.rotation);
    //         }
    // }
    void SpawningEnemyParam(int amount)
    {
        for (int i = 0; i < amount; i++)
         {
             // generate random spawn position between the defined values
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnPositionXa, spawnPositionXb),0 ,Random.Range(-spawnPositionZa,spawnPositionZb));

            // instantiate decoy
            Instantiate(Enemy, spawnPosition, Enemy.transform.rotation);
         }
    }
}
