using UnityEngine;

public abstract class Loot : MonoBehaviour
{
    [SerializeField] private ParticleSystem _useEffectPrefab;
    public virtual void Use(GameObject owner)
    {
        Instantiate(_useEffectPrefab, owner.transform.position, Quaternion.identity);
    }
}
