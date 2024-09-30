using UnityEngine;

public class SphereStarter : MonoBehaviour
{
    private Rigidbody _rigiddody;

    private void Start()
    {
        _rigiddody = GetComponent<Rigidbody>();
        _rigiddody.sleepThreshold = 0;
        //_rigiddody.WakeUp();
    }

}
