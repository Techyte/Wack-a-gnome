using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rb;

    [SerializeField] private float walkSpeed;
    [SerializeField] private Animator hammerAnimator;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 dir = Vector2.zero;

        dir.y = Input.GetAxisRaw("Vertical");

        dir.Normalize();
        
        _rb.velocity = dir * walkSpeed;

        if (Input.GetMouseButtonDown(0))
        {
            hammerAnimator.SetTrigger("useHammerLeft");
        }
        
        if (Input.GetMouseButtonDown(1))
        {
            hammerAnimator.SetTrigger("useHammerRight");
        }
    }
}
