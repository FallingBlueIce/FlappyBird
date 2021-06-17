using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird
{
    public class Player : MonoBehaviour
    {

        public Animator animator;
        public Rigidbody2D rb;

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
                    //rb.AddForce(new Vector2(0.0f, 10.0f));
                    rb.velocity = new Vector2(0.0f, 1500.0f);
                }
            }
            
        }
    }

}
