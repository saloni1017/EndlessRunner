using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentGenerator : MonoBehaviour
{
    public GameObject[] segment;

    [SerializeField] int zPos = 48;
    [SerializeField] bool creatingSegemnt = false;
    [SerializeField] int segementNum;

    void Update()
    {
        if(creatingSegemnt == false)
        {
            creatingSegemnt = true;
            StartCoroutine(SegementGen());
        }
    }

    IEnumerator SegementGen()
    {
        segementNum = Random.Range(0, 3);
        Instantiate(segment[segementNum], new Vector3(0,0,zPos), Quaternion.identity);
        zPos += 48;
        yield return new WaitForSeconds(3f);
        creatingSegemnt = false;
    }
    
}
