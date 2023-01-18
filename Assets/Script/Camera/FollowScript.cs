using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{

    [SerializeField] private Transform _objectToFollow;


    private void LateUpdate()
    {
        transform.position = new Vector3(_objectToFollow.position.x, _objectToFollow.position.y, transform.position.z);
    }
}
