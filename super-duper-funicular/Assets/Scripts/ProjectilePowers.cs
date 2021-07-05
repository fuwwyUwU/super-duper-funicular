using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePowers : MonoBehaviour
{
    public bool cloneBool;


    void Start()
    {
        
    }

    public void Clone()
    {
        Instantiate(gameObject);
    }




}
