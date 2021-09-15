using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Rigidbody2D rb2d;
    Vector2 startPosition;
    public int travelMax;
    public int Damage;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if(Vector2.Distance(startPosition, transform.position) > travelMax)
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb2d.velocity = transform.right * 9;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Baddy")
        {
            collision.gameObject.BroadcastMessage("Damage" , Damage);
        }
        
    }
}
