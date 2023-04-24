using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private Animator _crossfade;
    [SerializeField] private float transitionTime = 1f;

    public void LoadBattle()
    {
        StartCoroutine(LoadBattleCoroutine());
    }

    private IEnumerator LoadBattleCoroutine()
    {
        _crossfade.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(1);
    }
}
