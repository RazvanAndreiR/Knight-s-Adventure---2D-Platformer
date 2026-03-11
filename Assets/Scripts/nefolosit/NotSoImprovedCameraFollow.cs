using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImprovedCameraFollow : MonoBehaviour
{

    public float followSpeed = 2f;
    public float yoffset = 2.5f;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y +yoffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed*Time.deltaTime);
    }
}
