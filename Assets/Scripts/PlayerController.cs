using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    Vector2 moveInput;
    private Rigidbody2D rb2d; 
    private float Hp = 5f;
    private int starCount;

    public TextMeshProUGUI heartText;
    public TextMeshProUGUI starText;
    //walk left-right
    private float move; 
    [SerializeField] private float speed;
    
    //jump
    [SerializeField] float jumpForce;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //walk with addforce
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb2d.AddForce(moveInput * speed);
        rb2d.linearDamping = 1;
        
        //jump
        if (Input.GetButton("Jump"))
        {
            rb2d.AddForce(new Vector2(rb2d.linearVelocity.x, jumpForce));
        }
    }
    
    public void TakeDamage(int damage)
    {
        Hp -= damage;
        if (heartText != null)
        {
            heartText.text = Hp.ToString();
        }
        
        if (Hp <= 0)
        {
            OnGameOver();
            Hp = 0;
        }
    }
    
    public void GetStars(int star)
    {
        starCount++;
        if (starText != null)
        {
            starText.text = starCount.ToString();
        }

        if (starCount >= 5)
        {
            OnGameWin();
            Hp = 0;
        }
    }
    
    public void OnGameWin()
    {
        spawnManager spawnManager = FindObjectOfType<spawnManager>();
        if (spawnManager != null)
        {
            spawnManager.GameWin();
        }
    }
    
    public void OnGameOver()
    {
        spawnManager spawnManager = FindObjectOfType<spawnManager>();
        if (spawnManager != null)
        {
            spawnManager.GameOver();
        }
    }
}
