using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RatCollision: MonoBehaviour
{
    public Transform playerTransform;
    public SpriteRenderer m_Renderer;
    public SpriteRenderer am_Renderer;



    void Start()
    {

    }

    void Update()
    {

        if (playerTransform != null)
        {
            if (transform.position.x < playerTransform.position.x)
            {
                m_Renderer.flipX = false;
                am_Renderer.flipX = true;
            }
            else
            {
                m_Renderer.flipX = true;
                am_Renderer.flipX = false;
            }

        }


    }
    private void OnTriggerEnter2D(Collider2D other) 
    { 
        if (other.gameObject.CompareTag("Rat"))
        {
            Destroy(gameObject); // Desaparece
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        } 
    }
}







