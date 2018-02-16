using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GcuHealth : MonoBehaviour
{
    public Image healthBar;
    public float health;
    public float maxHealth = 100f;
    public float gcuHealth = 10f;
    public bool gameOver = false;
    public int score = 0;
    public bool sup;
    public Text scoreText;

    // Use this for initialization
    void Start()
    {
        health = maxHealth;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = health / maxHealth;
        if (gameOver == true)
        {
            Application.LoadLevel("EndScene");
        }
        scoreText.text = "Score:" + score.ToString();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "EnemyShipTag")
        {
            bool lazy = col.GetComponent<EnemyScript>().isLazy;
            if (lazy == true)
            {
                gcuHealth -= 1f;
                GcuFail();
                health -= 10f;
            }

            if (lazy == false)
            {
                score++;
            }
        }
    }

    void GcuFail()
    {
        if (gcuHealth <= 0f)
        {
            gameOver = true;
        }
    }
}
