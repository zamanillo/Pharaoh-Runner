using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCreator : MonoBehaviour
{
    [SerializeField] GameObject[] platformPrefab;
    [SerializeField] Transform referencePoint;
    [SerializeField]  GameObject lastCreatedPlatform;
    [SerializeField] float distancePlatforms=1;

    float lastPlatformWidth;
    public bool isPaused=false;
    
      void Update()
    {
        if (lastCreatedPlatform.transform.position.x < referencePoint.position.x -1 && !isPaused)
        {
            
            var startPoint = new Vector3(referencePoint.position.x + lastPlatformWidth + distancePlatforms, referencePoint.position.y, referencePoint.position.z);
            lastCreatedPlatform = Instantiate(platformPrefab[Random.Range(0,platformPrefab.Length)], startPoint, Quaternion.identity);
            BoxCollider2D collider = lastCreatedPlatform.GetComponent<BoxCollider2D>();
            lastPlatformWidth = collider.bounds.size.x;
        }
    }
}
