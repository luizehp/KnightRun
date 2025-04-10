using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;



public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 3.0f;

    public Animator animator;

    public Transform groundCheck;
    public AudioSource audio;
    public AudioSource audioMorte;
    bool isDead = false;


    [SerializeField] private TextMeshProUGUI pointsText;

    int points = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) return;
        Jump();
        float moveHorizontal = Input.GetAxis("Horizontal");
        animator.SetFloat("Horizontal", moveHorizontal);
        rb.linearVelocity = new Vector2(moveHorizontal * speed, rb.linearVelocity.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Coletavel")
        {

            audio.Play();
            GameConstroller.Collect();
            points++;
            pointsText.text = "Points: " + points.ToString();
            Destroy(other.gameObject);
        }
        if (other.tag == "Spike" && !isDead)
        {
            isDead = true;
            rb.linearVelocity = new Vector2(0, 0);
            animator.SetTrigger("Death");
            audioMorte.Play();
            rb.gravityScale = 0;
        }
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Ground())
        {
            rb.AddForce(new Vector2(0, 350.0f));
        }
    }

    private bool Ground()
    {
        if (rb.linearVelocity.y <= 0)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, 0.5f);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
