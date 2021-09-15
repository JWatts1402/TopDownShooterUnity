using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyManagement : MonoBehaviour
{
    Transform playerTransform;
    Vector2 playerposition;
    System.Random rnd = new System.Random();
    int x;
    int y;
    public float count = 0;
    float count2 = 1;
    float countReq = 40; 
    bool posChecked = false;
    Vector2 spawnpos;
    float timer = 2;
    public GameObject Enemy;
    public GameObject spawner;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = FindObjectOfType<PlyaerMovement>().transform;
        x = rnd.Next(-30, 30);
        y = rnd.Next(-15, 15);
        spawnpos = new Vector2(x, y);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        spawnpos = new Vector2(x, y);
        playerposition = playerTransform.position;

        if (timer <= 0)
        {
            count++;
            if (count % countReq == 0)
            {
                count2++;
                countReq = countReq / 2;
            }
            timer = (2f - (0.2f * math.pow(0.95f, count)));
             for (int i = 1; i <= count2; i++) {
                spawnEnemy();
            }
        }
    }
    void spawnEnemy()
        {
            while (posChecked == false)
            {               
                x = rnd.Next(-30, 30);
                y = rnd.Next(-15, 15);
                spawnpos = new Vector2(x, y);  

                if (Vector2.Distance(spawnpos, playerposition) > 16)
                {
                    posChecked = true;
                }
            }

            Instantiate(Enemy, spawnpos, quaternion.identity);
            x = rnd.Next(-30, 30);
            y = rnd.Next(-15, 15);
            posChecked = false;
    }
    
    }