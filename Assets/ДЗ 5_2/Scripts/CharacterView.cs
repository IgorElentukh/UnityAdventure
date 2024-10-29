using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterView
{
    private readonly int IsRunningKey = Animator.StringToHash("IsRunning");
    private readonly int IsJumpingKey = Animator.StringToHash("IsJumping");
    private readonly int IsHitKey = Animator.StringToHash("IsHit");
    private readonly int IsDeadKey = Animator.StringToHash("IsDead");
    
    private Animator _animator;

    public CharacterView(Animator animator)
    {
        _animator = animator;
    }

    public void StartRunning() => _animator.SetBool(IsRunningKey, true);

    public void StopRunning() => _animator.SetBool(IsRunningKey, false);

    public void StartJumping() => _animator.SetBool(IsJumpingKey, true);

    public void StopJumping() => _animator.SetBool(IsJumpingKey, false);

    public void GetHit() => _animator.SetTrigger(IsHitKey);

    public void Die() => _animator.SetTrigger(IsDeadKey);

    public void SwitchInjuredLayer() => _animator.SetLayerWeight(1, 1);

}
