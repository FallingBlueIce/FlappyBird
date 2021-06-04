using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeCollider : MonoBehaviour
{
    private Transform up;
    private Transform down;
    private GameManager mgr;
    private bool hasCounted = false;

    private void Start()
    {
        up = transform.GetChild(0);
        //down = transform.GetChild(1);
        mgr = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        
        if (mgr.bird.transform.position.x > up.position.x && !hasCounted)
        {
            mgr.score++;
            hasCounted = true;
        }
    }
}
