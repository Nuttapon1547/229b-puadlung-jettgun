using UnityEngine;

public class Sensor : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        spawnManager spawnController = FindObjectOfType<spawnManager>();
        if (other.gameObject.CompareTag("Player"))
        {
            spawnController.GameOver();
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
