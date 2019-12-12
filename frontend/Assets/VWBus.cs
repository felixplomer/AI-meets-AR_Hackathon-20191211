using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VWBus : MonoBehaviour
{

    public Material material;

    // Start is called before the first frame update
    void Start()
    {
        foreach (MeshRenderer mr in GetComponentsInChildren<MeshRenderer>()){
            mr.material = material;
            mr.materials[0] = material;
        }   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
