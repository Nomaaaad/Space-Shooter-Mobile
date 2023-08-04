using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float parallaxSpeed;

    private float spriteHeight;
    private Vector3 startPostition;

    void Start()
    {
        startPostition = transform.position;
        spriteHeight = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    void Update()
    {
        transform.Translate(Vector3.down * parallaxSpeed * Time.deltaTime);

        if (transform.position.y < startPostition.y - spriteHeight)
        {
            transform.position = startPostition;
        }
    }
}
