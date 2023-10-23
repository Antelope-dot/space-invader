using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    private bool destroyed = false;
    private SpriteRenderer _spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Asteroid")
        {
            if (!destroyed)
            {
                FindObjectOfType<GameManager>().buildingDestroyed -= 1;
                destroyed = true;
                _spriteRenderer.sprite = Resources.Load<Sprite>("Building_destroyed");
            }
        }
    }

    public bool Destroyed()
    {
        return destroyed;
    }
}
