using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D BulletRigidBody;
    public float speedBullet = 2000.0f;
    public float MaxLife = 10.0f;
    public float score;

    private void Awake()
    {
        BulletRigidBody = GetComponent<Rigidbody2D>();
    }

    public void Launch(Vector2 direction)  // take vector X for bullet direction  
    {
        BulletRigidBody.AddForce(direction * this.speedBullet);
        Destroy(this.gameObject, this.MaxLife);
    }

    private void OnCollisionEnter2D(Collision2D collision) // function MonoBehaviour handle 2d collision 
    {
        Destroy(this.gameObject);
        score++;
    }
}