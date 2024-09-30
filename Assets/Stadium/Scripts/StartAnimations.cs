using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimations : MonoBehaviour
{
    [SerializeField] private List<Animator> _animators = new List<Animator>();
    [SerializeField] private List<ParticleSystem> _fireworks = new List<ParticleSystem>();

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {          
            foreach (var animator in _animators)
                animator.SetTrigger("Play");

            foreach(ParticleSystem particle in _fireworks)
                particle.Play();
        }
    }
}
