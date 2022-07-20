using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int x = Random.Range(-2,2);
        int z = Random.Range(-2, 2);
        transform.localPosition += new Vector3(x, 2, z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
