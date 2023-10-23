using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Sprite[] sprites;
    public float size = 1.0f;
    public float minsize = 0.5f;
    public float maxSize = 1.5f;
    public float speed = 50.0f;
    public float maxLifetime = 30.0f;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;
    public AudioSource  audioSource;
    public AudioClip    audioClip;
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
        // Spite randomizatoin sprites[Random.Range(0, sprites.Length)];
        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);
        this.transform.localScale = Vector3.one * this.size;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 90 * Time.deltaTime));
    }

    private void Awake()
    {
        _spriteRenderer = GetComponent < SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void SetTrajectory(Vector2 direction)
    {
        _rigidbody.AddForce(direction * this.speed);
        Destroy(this.gameObject, this.maxLifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Laser(Clone)")
        {
           if (this.size * 0.5f >= this.minsize)
            {
                CreateSplit();
                CreateSplit();
            }

            audioSource.PlayOneShot(audioClip);
            Destroy(this.gameObject, 0.1f);
        }
        if (collision.tag == "Building")
        {

            audioSource.PlayOneShot(audioClip);
            Destroy(this.gameObject);
        }
    }

    private void CreateSplit()
    {
        Vector2 position = this.transform.position;
        position += Random.insideUnitCircle * 0.5f;
        Asteroid half = Instantiate(this, position, this.transform.rotation);
        half.size = this.size * 0.5f;

        // Should be the same as trajectory variance in asteroid spawner
        float variance = Random.Range(-15.0f, 15.0f);
        Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);


        half.SetTrajectory(rotation * Vector3.down); 
    }
}
