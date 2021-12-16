using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Sprite sprites;
    public float size = 1.0f;
    public float minSize = 0.5f;
    public float maxSize = 1.5f;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidBody;


    // Start is called before the first frame update
    private void Start()
    {
        spriteRenderer.sprite = sprites;
        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);
        this.transform.localScale = Vector3.one * this.size;

        rigidBody.mass = this.size;
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    public void SetTrajectory(Vector2 direction)
    {
        rigidBody.AddForce(direction * 70.0f);
        Destroy(this.gameObject, 30.0f);
    }

     private void OnCollisionEnter2D(Collision2D collision) // function MonoBehaviour handle 2d collision 
    {
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "MapBorder")
        {
            Destroy(this.gameObject);
        } 
    }
}
