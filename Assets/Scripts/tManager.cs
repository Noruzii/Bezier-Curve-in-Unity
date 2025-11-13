using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tManager : MonoBehaviour
{
    public static tManager instance;

    [Range(0, 1)]
    public float T;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

}
