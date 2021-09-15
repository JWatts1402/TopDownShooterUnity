
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    public int health;
    public GameObject uipanel;
    public GameObject textchange;
    public AudioSource hitSound;
    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Baddy")
        {
            health -= 1;
            hitSound.Play();
            Destroy(collision.gameObject);
            if(health < 1)
            {
                uipanel.SetActive(true);


                this.gameObject.BroadcastMessage("PacifistScoreCheck");


                textchange.BroadcastMessage("DeathScore");      
                

                Destroy(this.gameObject);
            }
        }
    }
}
