using UnityEngine;

public class Player : MonoBehaviour
{
    //private RigidBody2D rigidBody2D;
    //Vector3 heading = Vector3.forward;
    public Bullet bulletObj;
    public float speedForce;
    public float turnSpeed;
    private bool wantImpulse;
    private float turnRatio;
    private Rigidbody2D rigidBody;

    public void Awake() // launch  before first frame 
    {
        rigidBody = GetComponent<Rigidbody2D>(); // pour get le rigid body de l'asset qui a ce component 
    }

    public void Update() //launch every frame
    {
    
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            turnRatio = 1.0f;
            Debug.Log(turnRatio);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            turnRatio = -1.0f;
            Debug.Log(turnRatio);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Shoot();
        }
        else if (Input.GetKey(KeyCode.RightArrow) == false || Input.GetKey(KeyCode.LeftArrow) == false) 
        {
            turnRatio = 0.0f;
            Debug.Log(turnRatio);
        }
  
    }

    private void FixedUpdate()
    {  // handle la physic 
    bool wantImpulse = Input.GetKey(KeyCode.Space);
        if (wantImpulse)
        {
            rigidBody.AddForce(this.transform.up * this.speedForce * 10); //  add force to the spaceship 
        }

        if (turnRatio != 0.0f)
        {
            rigidBody.AddTorque(turnRatio * this.turnSpeed);
        } else
        {
            rigidBody.angularVelocity = 0;
        }

    }
 
    private void Shoot()
    {
        Bullet bulletInstance = Instantiate(this.bulletObj, this.transform.position, this.transform.rotation);
        bulletInstance.Launch(this.transform.up); // axe  y 
    }

    private void OnCollisionEnter2D(Collision2D collision) // function MonoBehaviour handle 2d collision 
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
}
