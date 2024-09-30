using UnityEngine;

public class BulletLoot : Loot
{
    [SerializeField] private Bullet _bulletPrefab;

    public override void Use(GameObject owner)
    {
        Transform shootPoint = owner.GetComponentInChildren<ShootPoint>().transform;

        if (shootPoint != null)
        {
            Bullet newBullet = Instantiate(_bulletPrefab, shootPoint.position, Quaternion.identity, null);
            newBullet.Launch(shootPoint.forward);
        }

        base.Use(owner);
    }
}
