using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float movement = Input.GetAxis("Horizontal");
        if ((transform.position.x < 8.7f && movement > 0) || (transform.position.x > -8.7f && movement < 0))
        {
            transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("WHY ISNT THE GAME OVER YET!");
        FindObjectOfType<GameManager>().GameOver();
    }
}
