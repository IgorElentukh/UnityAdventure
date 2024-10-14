using UnityEngine;

public class Ship : MonoBehaviour
{   
    [field: SerializeField] public Transform SailTransform { get; private set; }

    public Rigidbody Rigidbody { get; private set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }
}
