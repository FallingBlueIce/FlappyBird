using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird
{
    public class Player : MonoBehaviour
    {

        public Animator animator;
        public Rigidbody2D rb;
        public AudioClip jump1;
        public AudioClip jump2;
        public AudioSource audioPlayer;

        public bool onEnterGame = false;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if (onEnterGame)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))
                {
                    //rb.AddForce(new Vector2(0.0f, 100.0f));
                    rb.velocity = new Vector2(0.0f, 1800.0f);
                    int id = Random.Range(0, 2);
                    switch(id){
                        case 0: 
                            audioPlayer.clip = jump1;
                            break;
                        case 1:
                            audioPlayer.clip = jump2;
                            break;
                    }
                    audioPlayer.Play();
                }
            }
            
        }
    }

}
