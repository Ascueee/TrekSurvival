using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class WallRunning : MonoBehaviour
{
    [SerializeField] LayerMask isWall;
    [SerializeField] float distanceFromWall;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WallCollision();
    }

    void WallCollision()
    {
        RaycastHit hit;
        

        if (Physics.Raycast(gameObject.transform.position, Vector3.right, out hit, distanceFromWall, isWall))
        {
            print("hit from the right side");
            
        }
    }
}
