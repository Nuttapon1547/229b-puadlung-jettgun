using UnityEngine;
using UnityEngine.SceneManagement;

public class spawnManager : MonoBehaviour
{
    public GameObject GameWinPanel;
    public GameObject GameOverPanel;
    public PlayerController playerMovement;
    public Transform[] SpawnPoints;
    public GameObject EnemyPrefab;

    void Start()
    {
        playerMovement.enabled = true;
        GameOverPanel.SetActive(false);
        GameWinPanel.SetActive(false);
        InvokeRepeating("Spawn", 2, 1);
    }
    void Spawn()
    {
        int spawnIdx = Random.Range(0, SpawnPoints.Length);
        Instantiate(EnemyPrefab, SpawnPoints[spawnIdx].position, Quaternion.identity);
    }
    
    public void GameWin()
    {
        CancelInvoke(nameof(Spawn));
        
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies) 
        {
            Destroy(enemy);
        }
        playerMovement.enabled = false;
        
        GameWinPanel.SetActive(true);
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
    
    public void RestartGame()
    {
        var s = SceneManager.GetActiveScene();
        SceneManager.LoadScene(s.name);
    }
}
