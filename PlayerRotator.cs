using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotator
{
    private float _rotateSpeed;

    public void ProcessRotateTo(Vector3 direction, Transform owner)
    {
        Quaternion lookRotation = Quaternion.LookRotation(direction.normalized);
        float step = _rotateSpeed * Time.deltaTime;

        owner.rotation = Quaternion.RotateTowards(owner.rotation, lookRotation, step);
    }
}
