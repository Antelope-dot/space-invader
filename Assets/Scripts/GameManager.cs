using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip victoryTheme;
    public Canvas canvas;
    public GameObject vict_text;
    public GameObject retry;
    public int buildingDestroyed = 3;
    private bool gameWon = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //canvas.enabled = false;
        vict_text.SetActive(false);
        retry.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.buildingDestroyed <= 0)
        {
            GameOver();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.R) && gameWon) {
            SceneManager.LoadScene("SampleScene");
        }
        
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
    public void GameWon()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(victoryTheme, 1f);
        vict_text.SetActive(true);
        retry.SetActive(true);
        gameWon = true;
    }
}
