using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Take : MonoBehaviour
{
    [SerializeField] private Transform _arm;
    
    private float _distance = 3;
    private Rigidbody _rigidbody;
    private Camera _camera;
    private Outline _outline;
    public bool _isTheObjectInYourHand;
    private void Start()
    {
        _camera = Camera.main;
        _rigidbody = GetComponent<Rigidbody>();
        _outline = GetComponent<Outline>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (_rigidbody.isKinematic && _isTheObjectInYourHand)
            {
                _rigidbody.isKinematic = false;
                _isTheObjectInYourHand = false;
            }
            if (Physics.Raycast(ray, _distance) && _outline.OutlineWidth>0)
            {
                _rigidbody.isKinematic = true;
                _isTheObjectInYourHand = true;
                _rigidbody.MovePosition(_arm.position);
            }
        }
    }
    private void FixedUpdate()
    {
        if (_rigidbody.isKinematic)
        {
            gameObject.transform.position = _arm.position;
            transform.rotation = new Quaternion();
        }
        if (_isTheObjectInYourHand)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _rigidbody.isKinematic = false;
                _rigidbody.AddForce(_camera.transform.forward * 500);
                _isTheObjectInYourHand = false;
            }
        }
    }
}
