using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePowers : MonoBehaviour
{
    public bool cloneBool;
    public bool stopBool;

    void Start()
    {
        
    }

    public void Clone()
    {

        transform.Rotate(Vector3.forward * 20);

        
    }

}
