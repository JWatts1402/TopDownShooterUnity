using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    Transform playerTransform;
    Vector2 playerPosition;
    public int equipValue;
    float distance;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = FindObjectOfType<PlyaerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = playerTransform.position;
        distance = Vector2.Distance(playerPosition, transform.position);

        if (distance < 2)
        {
            //ui popup for item
            if (Input.GetKeyDown("e"))
            {
                ItemEquip();
            }
        }
    }

    public void ItemEquip()
    {
        Destroy(this.gameObject);
        playerTransform.BroadcastMessage("GunEquip", equipValue);
    }
}
