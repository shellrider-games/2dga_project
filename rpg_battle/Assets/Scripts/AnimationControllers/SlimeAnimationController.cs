using System.Collections;
using System.Collections.Generic;
using Spine;
using UnityEngine;
using Spine.Unity;

public class SlimeAnimationController : MonoBehaviour
{
    public delegate void ShotHitCallback();

    [SerializeField] private AudioClip _hurtAudio;
    [SerializeField] private AudioSource _audio;
    [SerializeField] private SlimeProjectileEffectAnimation _projectile;
    
    [SerializeField] private SkeletonAnimation _skeleton;
    
    [SerializeField] private AnimationReferenceAsset idle;
    [SerializeField] private AnimationReferenceAsset getHit;
    [SerializeField] private AnimationReferenceAsset attack;
    
    public void Start()
    {
        _skeleton.state.SetAnimation(0, idle, true);
    }
    
    public void GetHit()
    {
        TrackEntry track = _skeleton.state.SetAnimation(0, getHit, false);
        track.Complete += delegate { _skeleton.state.SetAnimation(0, idle, true); };
        _audio.PlayOneShot(_hurtAudio);
    }

    public void Shoot(ShotHitCallback callback)
    {
        TrackEntry track = _skeleton.state.SetAnimation(0, attack, false);
        track.Complete += delegate
        {
            _skeleton.state.SetAnimation(0, idle, true);
            _projectile.Shoot(() =>
            {
                callback();
            });
        };
        
    }
}
