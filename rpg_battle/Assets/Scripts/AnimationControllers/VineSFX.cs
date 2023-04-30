using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineSFX : MonoBehaviour
{
    [SerializeField] private AudioSource _sfx;

    public void PlaySFX()
    {
        _sfx.Play();
    }
}
