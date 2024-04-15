using UnityEngine;

public class Cupcake : MonoBehaviour
{
    private float _speed;
    [SerializeField] private GameObject smashedCupcake;
    [SerializeField] private GameObject smashedParticle;
    public bool infected = false;
    
    public void Init(float speed)
    {
        _speed = speed;
    }

    private void Update()
    {
        Vector2 position = transform.position;
        position.x += _speed * Time.deltaTime;
        transform.position = position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Smash"))
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("FallDown"))
        {
            if (infected)
            {
                Debug.Log("U lost!!!!!");
            }
            else
            {
                float xOffset = Random.Range(-0.2f, 0.2f);
                float yoffset = Random.Range(-0.4f, 0.4f);

                Vector2 position = transform.position;
                position.x += xOffset;
                position.y += yoffset;

                Instantiate(smashedCupcake, position, Quaternion.identity);
                Instantiate(smashedParticle, position, Quaternion.identity);
                Destroy(gameObject);   
            }
        }
    }
}
