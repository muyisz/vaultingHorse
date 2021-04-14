using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class houseRidimg : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 17f;
    public float turnSpeed = 30f;
    SkinnedMeshRenderer render;
    Color clo;
    Color orclo;
    void Start()
    {
        render = transform.GetComponentInChildren<SkinnedMeshRenderer>();
        clo = orclo = render.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        render.material.color = clo;
        move();
        turn();
    }

    void move()
    {
        transform.Translate(new Vector3(0, 0, 1) * speed * Time.deltaTime);
    }

    void turn()
    {
        float x = Input.GetAxis("Horizontal");
        if (Mathf.Abs(x) > 0.5f) 
        {
            transform.Rotate(0, turnSpeed * x * Time.deltaTime, 0);
        }
        else
        {
            Quaternion mid = Quaternion.identity;
            transform.rotation = Quaternion.Slerp(transform.rotation, mid, 0.2f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="tree"||other.gameObject.tag=="house")
        {
            GetComponentInChildren<player>().die(1);
        }
    }

}
