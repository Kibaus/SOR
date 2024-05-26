using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;
using VSCodeEditor;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _turnspeed = 360;
    private Vector3 input01;

    void Update()
    {
        GatherInput();
        Look();
    }

    void FixedUpdate()
    {
        Move();
    }
    void GatherInput()
    {
        input01 = new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical"));
    }

    void Look()
    {
        if (input01 != Vector3.zero)
        {
            var relative = (transform.position + input01) - transform.position;
            var rot = Quaternion.LookRotation(relative, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation,rot, _turnspeed * Time.deltaTime);
        }
    }

    

    void Move()
    {
        _rb.MovePosition(transform.position + (transform.forward * input01.magnitude) * _speed * Time.deltaTime);
    }
}
