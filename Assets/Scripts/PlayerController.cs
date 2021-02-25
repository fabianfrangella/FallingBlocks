using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public event System.Action OnPlayerDeath;
    public float speed = 7;
    float screenHalfWidthInWorldUnits;
    float screenHalfHeigthInWorldUnits;
    // Start is called before the first frame update
    void Start()
    {
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize;
        screenHalfHeigthInWorldUnits = Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        CheckBorderCollision();
    }

    private void MovePlayer()
    {
        float velocity = 0;
        float inputY = Input.GetAxisRaw("Vertical");
        float inputX = Input.GetAxisRaw("Horizontal");
        if (inputX != 0)
        {
            velocity = inputX * speed;
            transform.Translate(Vector2.right * velocity * Time.deltaTime);
        }
        if (inputY != 0)
        {
            velocity = inputY * speed;
            transform.Translate(Vector2.up * velocity * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        if (triggerCollider.tag == "Falling Block")
        {
            if (OnPlayerDeath != null)
            {
                OnPlayerDeath();
            }
            Destroy(gameObject);
        }
    }

    private void CheckBorderCollision()
    {
        if (transform.position.x < -(screenHalfWidthInWorldUnits + (transform.localScale.x / 2f)))
        {
            transform.position = new Vector2(screenHalfWidthInWorldUnits, transform.position.y);
        }
        if (transform.position.x > screenHalfWidthInWorldUnits + (transform.localScale.x / 2f))
        {
            transform.position = new Vector2(-screenHalfWidthInWorldUnits, transform.position.y);
        }

        if (transform.position.y < -(screenHalfHeigthInWorldUnits + (transform.localScale.y / 2f)))
        {
            transform.position = new Vector2(transform.position.x, screenHalfHeigthInWorldUnits);
        }
        if (transform.position.y > screenHalfHeigthInWorldUnits + (transform.localScale.y / 2f))
        {
            transform.position = new Vector2(transform.position.x, -screenHalfHeigthInWorldUnits);
        }
    }
}
