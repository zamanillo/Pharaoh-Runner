using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] float limit = 50;


    void Update()
    {
        //transform.Translate(-1, 0, 0);

        transform.position += new Vector3(-speed, 0, 0)*Time.deltaTime;

        if (transform.position.x < -limit) 
        {
            Destroy(gameObject);
        }
    }
}
