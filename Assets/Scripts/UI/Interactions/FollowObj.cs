using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObj : MonoBehaviour
{
    //TODO: GET THIS TO WORK!!
    [SerializeField] private GameObject objectToFollow;

    [Header("Follow Axis: ")] 
    [SerializeField] private bool x;
    [SerializeField] private bool y;
    [SerializeField] private bool z;

    private Vector3 _pos;
    private Vector3 _offset;
    private Vector3 _targetPos;
    private Vector3 _outPos;

    // Update is called once per frame
    private void Update()
    {
        _pos = gameObject.transform.position;
        _targetPos = objectToFollow.transform.position;
        _offset = _pos - _targetPos;
        print(_outPos);

        if (x) _outPos.x = _targetPos.x + _offset.x;
        else _outPos.x = _pos.x;
        
        if (y) _outPos.y = _targetPos.y + _offset.y;
        else _outPos.y = _pos.y;
        
        if (z) _outPos.z = _targetPos.z + _offset.z;
        else _outPos.z = _pos.z;
        
        this.transform.position = new Vector3(_outPos.x, _outPos.y, _outPos.z);
    }
}
