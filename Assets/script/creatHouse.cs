using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creatHouse : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Transform> houseList;
    public Transform player;
    public float time = 3;
    public float dis = 50;
    void Start()
    {
        StartCoroutine(creatHou());
    }

    // Update is called once per frame
    IEnumerator creatHou()
    {
        while(true)
        {
            int i = Random.Range(0, houseList.Count);
            Transform newHouse = houseList[i];
            Vector3 pos = new Vector3(Random.Range(-13f, 13f), 0, dis);
            pos.z += player.position.z;
            Transform hou = Instantiate(newHouse, pos, Quaternion.identity);
            yield return new WaitForSeconds(time);
        }
    }
}
