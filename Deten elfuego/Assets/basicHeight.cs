using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicHeight : MonoBehaviour
{
    [SerializeField]
    private float heightToSum;
    
    public float getHeight()
    {
        return heightToSum;
    }
}
