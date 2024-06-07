using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpin : MonoBehaviour
{
    [SerializeField] private float _rotatespeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, _rotatespeed * Time.deltaTime, 0f, Space.Self);
    }
}
