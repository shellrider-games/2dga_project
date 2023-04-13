using System;
using System.Collections;
using System.Collections.Generic;
using Spine;
using UnityEngine;
using Spine.Unity;
using Event = Spine.Event;

public class DruidAnimationController : MonoBehaviour
{
    public delegate void StompCallback();

    [SerializeField] private VineEffectAnimation _vineEffectAnimation;

    [SerializeField] private SkeletonAnimation _skeleton;
    [SerializeField] private AnimationReferenceAsset idle;
    [SerializeField] private AnimationReferenceAsset stomp;

    public void Start()
    {
        _skeleton.state.SetAnimation(0, idle, true);
    }

    public void Stomp(StompCallback callback)
    {
        TrackEntry track = _skeleton.state.SetAnimation(0, stomp, false);
        track.Complete += delegate { _skeleton.state.SetAnimation(0, idle, true); };
        track.Event += delegate(TrackEntry _, Event e)
        {
            if (e.Data.Name != "vineSpawn" || _vineEffectAnimation is null) return;
            _vineEffectAnimation.Trigger();
            void HandleCallback()
            {
                callback();
                _vineEffectAnimation.OnEnemyHit -= HandleCallback;
            }
            _vineEffectAnimation.OnEnemyHit += HandleCallback;
        };
    }
}