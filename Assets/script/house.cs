using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class house : MonoBehaviour
{
    public float moveSpeed = 10f;
    SkinnedMeshRenderer render;
    Color clo;
    Color orclo;
    // Start is called before the first frame update
    void Start()
    {
        render = transform.GetComponentInChildren<SkinnedMeshRenderer>();
        clo = orclo = render.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        move();
        render.material.color = clo;
    }

    private void LateUpdate()
    {
        clo = orclo;
    }
    void move()
    {
        transform.position += (transform.forward * moveSpeed * Time.deltaTime);
    }

    public void changeColor(Color co)
    {
        clo = co;
    }
}
