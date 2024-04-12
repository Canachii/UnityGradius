using System;
using UnityEngine;

public class Missile : Projectile
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
}