using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, IGrabble
{
    public Transform Transform => transform;

    public void OnGrab()
    {
        transform.localScale = new Vector3(2, 2, 2);
    }

    public void OnRelease()
    {
        transform.localScale = Vector3.one;
    }
}
