using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecreatedWaste : MonoBehaviour
{
    public float speed;
    public bool moving;

    void Update()
    {
        if (moving){
            transform.position = new Vector3(transform.position.x - (speed * Time.deltaTime), transform.position.y, 0);
        }
    }
}
