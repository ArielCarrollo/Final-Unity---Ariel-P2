using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject EnemySpecial;
    public GameManager Gmc;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("CreateEnemy", 2);
        Invoke("CreateSpecialEnemy", 7);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CreateEnemy()
    {
        GameObject enemy = Instantiate(Enemy, new Vector3(10f, Random.Range(3.50f, -4.5f), 0), transform.rotation);
        enemy.GetComponent<EnemyController>().SetGameManager(Gmc);
        Invoke("CreateEnemy", 2);
    }
    void CreateSpecialEnemy()
    {
        GameObject enemy2 = Instantiate(EnemySpecial, new Vector3(12f, Random.Range(3.50f, -4.5f), 0), transform.rotation);
        enemy2.GetComponent<EnemySpecialControl>().SetGameManager(Gmc);
        Invoke("CreateSpecialEnemy", 9);
    }
}
