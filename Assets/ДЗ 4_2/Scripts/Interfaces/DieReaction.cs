using UnityEngine;

public class DieReaction : IReactOnPlayerBehaviour
{
    private const float scaleMultiplier = 2f;
    
    public void ReactOnPlayer(EnemyController owner)
    {
        Transform ownerTransform = owner.gameObject.transform;

        float currentScale = ownerTransform.localScale.x;
        currentScale += Time.deltaTime * scaleMultiplier;

        ownerTransform.localScale = new Vector3(currentScale, currentScale, currentScale);

        if (ownerTransform.localScale.x >= 2)
        {
            MonoBehaviour.Destroy(owner.gameObject);
            MonoBehaviour.Instantiate(owner.DieEffect, ownerTransform.position, Quaternion.identity);
        }
    }
}
