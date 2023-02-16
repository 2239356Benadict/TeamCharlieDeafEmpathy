using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyScript : MonoBehaviour
{
    // Do not detstroy the gameobject attached with this object
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }


}
