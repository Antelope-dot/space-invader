using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moon : MonoBehaviour
{
    public float speed = 1.0f;
    public bool been_hit = false;
    public int health = 50;
    public AsteroidSpawner spawner;
    private SpriteRenderer _spriteRenderer;
    private bool gameWon = false;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        slider.maxValue = health;
        slider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= 4)
        {

            if (!gameWon)
            {
                _spriteRenderer.sprite = Resources.Load<Sprite>("Happy_moon");
                gameWon = true;
                FindObjectOfType<GameManager>().GameWon();
            }
        }
        else if  (been_hit == false)
        {
            transform.position += new Vector3(0, -1, 0) * Time.deltaTime * speed;
        }

        if (health <= 0)
        {
            FindObjectOfType<GameManager>().GameOver();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.name == "Laser(Clone)")
        {
            if (!gameWon)
            {
                spawner.startSpawning = true;
                health -= 1;
                slider.value -= 1;
            }
        }
    }
}
