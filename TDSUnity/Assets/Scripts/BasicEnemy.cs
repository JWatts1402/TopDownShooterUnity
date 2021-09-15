using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public GameObject pistol;
    public GameObject shotgun;
    public GameObject rifle;
    Transform playerTransform;
    Vector2 rot;
    Vector2 playerPosition;
    int Health;
    float dir;
    float distance;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = FindObjectOfType<PlyaerMovement>().transform;   
        Health = 2;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerPosition = playerTransform.position;
        distance = Vector2.Distance(transform.position, playerPosition); 
        Move();
    }

    void Move()
    {
        float angle = AngleBetweenTwoPoints(transform.position, playerPosition);
        transform.rotation = transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    
        rot = (transform.position - playerTransform.position).normalized;
        rb2d.MovePosition(rb2d.position - rot * 6 * Time.deltaTime);
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
    void Damage(int x)
    {
        Health -= x;
        if (Health < 1)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(this.gameObject);
        playerTransform.BroadcastMessage("Score");
        Drop();
    }
    void Drop()
    {

        int drop = Random.Range(1, 51);
        if (drop > 40)
        {
            int i = Random.Range(0, 3);

            switch (i)
            {
                case 0:
                    Instantiate(pistol, transform.position, Quaternion.identity);
                    break;
                case 1:
                    Instantiate(shotgun, transform.position, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(rifle, transform.position, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(pistol, transform.position, Quaternion.identity);
                    break;
            }
        }
       }
    }

