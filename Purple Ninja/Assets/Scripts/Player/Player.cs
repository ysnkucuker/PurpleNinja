using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float hiz;
    private Rigidbody2D rb;
    private bool sagaBak;
    private Animator myAnimator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         sagaBak = true;
         rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    { 
        float yatay = Input.GetAxis("Horizontal");
        TemelHareketler(yatay);
        YonCevir(yatay);
        
    }

    private void TemelHareketler(float yatay)
    {
        rb.linearVelocity = new Vector2(yatay * hiz, rb.linearVelocity.y);
        myAnimator.SetFloat("karakterHizi", Mathf.Abs(rb.linearVelocity.x));

    }

    private void YonCevir(float yatay)
    {
        if (yatay > 0 && !sagaBak || yatay < 0 && sagaBak)
        {
            sagaBak = !sagaBak;
            Vector3 yon = transform.localScale;
            yon.x *= -1;
            transform.localScale = yon;
        }
    }
}
