using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{
    private float topBound = 30;
    private float lowerBound = -10;
    void Start()
    {
        
    }

    void Update()
    {
        // if the object past the player view then destory the game object.
        if(transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowerBound)
        {
            Debug.Log("Game Over!!");
            Destroy(gameObject);
        }
    }
}
