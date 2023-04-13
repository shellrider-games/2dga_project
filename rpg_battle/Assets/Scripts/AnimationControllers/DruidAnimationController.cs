using System;
using System.Collections;
using System.Collections.Generic;
using Spine;
using UnityEngine;
using Spine.Unity;

public class DruidAnimationController : MonoBehaviour
{
    public delegate void StompCallback();
    
    [SerializeField]private SkeletonAnimation _skeleton;
    [SerializeField] private AnimationReferenceAsset idle;
    [SerializeField] private AnimationReferenceAsset stomp;

    public void Start()
    {
        _skeleton.state.SetAnimation(0, idle, true);
    }

    public void Stomp(StompCallback callback)
    {
        TrackEntry track = _skeleton.state.SetAnimation(0, stomp, false);
        track.Complete += delegate {
            _skeleton.state.SetAnimation(0, idle, true);
            callback();
        };
    }
    
}
