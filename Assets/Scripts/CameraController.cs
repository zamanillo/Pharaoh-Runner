using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] Transform player;
    [SerializeField] Vector3 cameraVelocity;
    [SerializeField] float smoothTime;
    [SerializeField] bool lookAtPlayer;
    [SerializeField] int lowerLimit = -2;

    void Update()
    {
        //transform.position = new Vector3 (transform.position.x, player.position.y, transform.position.z);

        if (player.position.y >= lowerLimit)
        {
            Vector3 targetPosition = new Vector3(transform.position.x, player.position.y-1, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref cameraVelocity, smoothTime);

            if (lookAtPlayer)
            {
                transform.LookAt(player);
            }
        }
    }
}


/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    Transform posicionCamara;
    //[SerializeField] float cameraSmooth;
    //[SerializeField] Vector3 cameraVelocity;
    //private Vector3 newPosition;

    private void Awake()
    {
        posicionCamara = GameObject.Find("PlayerAnimation").transform;
    }
   
    void Update()
    {
        this.transform.position = new Vector3(posicionCamara.position.x, posicionCamara.position.y, -10);

        //transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref cameraVelocity, cameraSmooth);
    }
}
*/