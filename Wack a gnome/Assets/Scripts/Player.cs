using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rb;

    [SerializeField] private float walkSpeed;
    [SerializeField] private Animator hammerAnimator;
    [SerializeField] private Transform leftSmashPos;
    [SerializeField] private Transform rightSmashPos;
    [SerializeField] private GameObject smashEffect;
    [SerializeField] private LayerMask smashedCupcakeLayer;

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

        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, 2, Vector2.up, 2, smashedCupcakeLayer);

        float movementReduction = 1 - Mathf.Clamp(hits.Length * 0.1f, 0f, 0.8f);
        
        Debug.Log(hits.Length);
        
        _rb.velocity = dir * (walkSpeed * movementReduction);

        if (Input.GetMouseButtonDown(0))
        {
            hammerAnimator.SetTrigger("useHammerLeft");
            StartCoroutine(SpawnLeftSmash());
        }
        
        if (Input.GetMouseButtonDown(1))
        {
            hammerAnimator.SetTrigger("useHammerRight");
            StartCoroutine(SpawnRightSmash());
        }
    }

    private IEnumerator SpawnLeftSmash()
    {
        yield return new WaitForSeconds(0.3f);
        GameObject effect = Instantiate(smashEffect, leftSmashPos.position, Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        Destroy(effect);
    }

    private IEnumerator SpawnRightSmash()
    {
        yield return new WaitForSeconds(0.3f);
        GameObject effect = Instantiate(smashEffect, rightSmashPos.position, Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        Destroy(effect);
    }
}
