using UnityEngine;

public class movement : MonoBehaviour
{
    private Rigidbody2D rb2d; 
    Vector2 moveInput;
    
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
            Debug.Log("Jump!"); // for debugging
        }
    }
}
