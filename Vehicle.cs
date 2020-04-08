using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    [SerializeField] private float speed;
    public bool isLog;
    
    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }


}
