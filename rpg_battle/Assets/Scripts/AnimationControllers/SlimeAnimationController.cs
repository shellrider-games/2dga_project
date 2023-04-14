using System.Collections;
using System.Collections.Generic;
using Spine;
using UnityEngine;
using Spine.Unity;

public class SlimeAnimationController : MonoBehaviour
{
    [SerializeField] private SkeletonAnimation _skeleton;
    
    [SerializeField] private AnimationReferenceAsset idle;
    [SerializeField] private AnimationReferenceAsset getHit;
    
    public void Start()
    {
        _skeleton.state.SetAnimation(0, idle, true);
    }
    
    public void GetHit()
    {
        TrackEntry track = _skeleton.state.SetAnimation(0, getHit, false);
        track.Complete += delegate { _skeleton.state.SetAnimation(0, idle, true); };        
    }
}
