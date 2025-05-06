using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public Transform[] SpawnPoints;
    public GameObject EnemyPrefab;

    void Start()
    {
        InvokeRepeating("Spawn", 2, 1);
    }
    void Spawn()
    {
        int spawnIdx = Random.Range(0, SpawnPoints.Length);
        Instantiate(EnemyPrefab, SpawnPoints[spawnIdx].position, Quaternion.identity);
    }
    
    public void GameOver()
    {
        CancelInvoke(nameof(Spawn));
       
        
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
        playerMovement.enabled = false;
        GameOverPanel.SetActive(true);
    }
}
