using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public delegate void onTrigged();
    public delegate void onPassed();
    public static onTrigged trigged;
    public static onPassed passed;

    bool isCounted = false;
    // Start is called before the first frame update
    void Start()
    {
        int height = Random.Range(-2,2);
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(-600.0f, 0.0f);
        transform.localPosition = new Vector3(transform.localPosition.x, 200.0f * height, transform.localPosition.z);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "BirdController")
            trigged();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isCounted && transform.position.x <= 540)
        {
            passed();
            isCounted = true;
        }
            
    }
}
