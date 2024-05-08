using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdControl : MonoBehaviour
{
    public AudioClip flyClip;
    public AudioClip gameOverClip;
    //public AudioClip gamePointClip;
    //public AudioClip BackGroundClip;
    private AudioSource audioSource;
    private Animator anim;
    GameObject obj;
    public float flyPower = 2700 ;
    GameObject gameController;
    //public bool Tag;
    
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        flyPower = 2700;       
        audioSource = obj.GetComponent<AudioSource>();
        anim = obj.GetComponent<Animator>();
        anim.SetFloat("flyPower", 0);
        anim.SetBool("isDead", false);

        audioSource.clip = flyClip;
        if (gameController == null)
        {
            gameController = GameObject.FindGameObjectWithTag("GameController");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!gameController.GetComponent<GameController>().isEndGame)
            {
                //Debug.Log("Fly");               
                audioSource.Play();
            }
            obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, flyPower));

        }
        anim.SetFloat("flyPower", obj.GetComponent<Rigidbody2D>().velocity.y);

    }

    private void OnCollisionEnter2D(Collision2D other)
    {    
        EndGame(); 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Tag = true;
        gameController.GetComponent<GameController>().GetPoint();  
        
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (Tag)
    //    {
    //        audioSource = obj.GetComponent<AudioSource>();
    //        audioSource.clip = gamePointClip;
    //        audioSource.Play();
    //        Tag = false;
    //    }
    //}

    void EndGame()
    {
        flyPower = 0;
        anim.SetBool("isDead", true);
        audioSource.clip = gameOverClip;
        audioSource.Play();       
        gameController.GetComponent<GameController>().EndGame();
    }
}