using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public delegate void OnCollision();
    public static OnCollision collied;
    void OnCollisionEnter2D (Collision2D  other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "BirdController")
        {
            collied();
        }
    }
}
