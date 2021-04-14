using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xuanZhuan : MonoBehaviour
{
    // Start is called before the first frame update
    public float turnSpeed=400f;
    public Transform root;
    public Vector3 tas;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = root.position + tas ;
        transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
    }
}
