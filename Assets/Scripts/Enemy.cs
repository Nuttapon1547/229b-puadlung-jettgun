using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private float speed = 1.5f;
    private Rigidbody2D rb2d;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject bullet;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        bullet = GameObject.FindGameObjectWithTag("Bullet");
    }

    void Update()
    {
        Vector3 d = player.transform.position - transform.position;
        Vector3 dir = d.normalized;
        rb2d.AddForce(dir * speed);
    }

    void OnCollisionEnter2D(Collision2D PlayerCollision)
    {
        if (PlayerCollision.gameObject.CompareTag("Player"))
        {
            Debug.Log("hit");
            PlayerController playerController = PlayerCollision.gameObject.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.TakeDamage(1);
            }
            Destroy(this.gameObject);
        }
        else if (PlayerCollision.gameObject.CompareTag("Bullet"))
        {
            Destroy(this.gameObject);
        }
    }
}
