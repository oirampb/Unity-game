using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class color : MonoBehaviour
{

    void Start()
    {
        Renderer _rend = this.GetComponent<Renderer>();
        _rend.material.color = Color.red;

    }
}
