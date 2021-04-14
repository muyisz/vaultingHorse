using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum playStatic
{
    onRide,
    onJump,
    toDead,
    toRide,
    dead,
}
public class player : MonoBehaviour
{
    Transform beRidHouse;
    public playStatic sta;
    public Rigidbody rig;
    public Transform zero;
    public Animator ani;
    public Vector3 jumpForce;
    public Transform ridHouse;
    public Transform nearHosue;
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
        beRidHouse = transform.parent.parent;
        sta = playStatic.onRide;
        rig = GetComponent<Rigidbody>();
        ani = GetComponentInChildren<Animator>();
        if (ridHouse == null)
        {
            ridHouse = transform.parent.parent;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (sta)
        {
            case playStatic.onRide:
                {
                    if (Input.GetButtonDown("Jump"))
                    {
                        jump();
                        ridHouse.GetComponent<houseRidimg>().enabled = false;
                        ridHouse.GetComponent<house>().enabled = true;
                        sta = playStatic.onJump;
                        beRidHouse = null;
                    }
                }
                break;
            case playStatic.onJump:
                {
                    cheakNearHouse();
                    if (Input.GetButtonUp("Jump"))
                    {
                        if (nearHosue == null)
                        {
                            sta = playStatic.toDead;
                            Debug.Log("todead");
                        }
                        else
                        {
                            sta = playStatic.toRide;
                            Debug.Log("toride");
                        }
                    }
                }
                break;
            case playStatic.dead:
                break;
            case playStatic.toDead:
                break;
            case playStatic.toRide:
                {
                    rig.isKinematic = true;
                    Transform ridpo = nearHosue.Find("ridePoint");
                    transform.position = Vector3.Lerp(transform.position, ridpo.position, 0.4f);
                    ridHouse = nearHosue;
                    transform.SetParent(ridpo);
                    transform.localPosition = Vector3.zero;
                    sta = playStatic.onRide;
                    ridHouse.GetComponent<house>().enabled = false;
                    ridHouse.GetComponent<houseRidimg>().enabled = true;
                }
                nearHosue = null;
                break;

        }
    }

    void jump()
    {
        houseRidimg hoRi = GetComponentInParent<houseRidimg>();
        float moveSpeed = hoRi.speed;
        rig.isKinematic = false;
        rig.velocity = new Vector3(0, 0, moveSpeed * Time.deltaTime);
        rig.AddForce(jumpForce);
    }

    void cheakNearHouse()
    {
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, 1.8f, Vector3.down, 10);
        if (hits.Length == 0)
        {
            nearHosue = null;
            return;
        }
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].transform.tag == "house")
            {
                nearHosue = hits[i].transform;
                nearHosue.transform.GetComponent<house>().changeColor(Color.yellow);
                return;
            }
        }
        nearHosue = null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="floor")
        {
            die(0);
        }
    }

    public void die(int cs)//向后1 向前0
    {
        sta = playStatic.dead;
        ani.SetInteger("static", cs);
        transform.parent = null;
        panel.SetActive(true);
    }
}
