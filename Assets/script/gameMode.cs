using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameMode : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Transform> floor;
    public List<Transform> floorQueue;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        creatFloor();
    }
    void creatFloor()
    {   
        Transform lastfloor = floor[floor.Count - 1];
        if (lastfloor.position.z < transform.position.z + 80) 
        {
            Transform pre = floorQueue[Random.Range(0, floorQueue.Count)];
            Transform newpre = Instantiate(pre, null);
            newpre.position = lastfloor.transform.position + new Vector3(0, 0, 50);
            floor.Add(newpre);
        }
        Transform last = floor[0];
        if (last.position.z < transform.position.z - 50) 
        {
            floor.RemoveAt(0);
            Destroy(last.gameObject);
        }
    }
}
