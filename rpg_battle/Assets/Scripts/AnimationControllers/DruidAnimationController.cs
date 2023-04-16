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

    public event Action OnTurnEnd;

    [SerializeField] private VineEffectAnimation _vineEffectAnimation;

    [SerializeField] private SkeletonAnimation _skeleton;
    [SerializeField] private AnimationReferenceAsset idle;
    [SerializeField] private AnimationReferenceAsset stomp;
    [SerializeField] private AnimationReferenceAsset getHit;

    public void Start()
    {
        _skeleton.state.SetAnimation(0, idle, true);
    }

    public void OnEnable()
    {
        _vineEffectAnimation.OnAnimationOver += EndTurn;
    }

    public void OnDisable()
    {
        _vineEffectAnimation.OnAnimationOver -= EndTurn;
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

    public void GetHit()
    {
        TrackEntry track = _skeleton.state.SetAnimation(0, getHit, false);
        track.Complete += delegate { _skeleton.state.SetAnimation(0, idle, true); };   
    }

    public void EndTurn()
    {
        OnTurnEnd?.Invoke();
    }
}