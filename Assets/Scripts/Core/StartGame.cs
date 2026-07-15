using Cysharp;
using Cysharp.Threading.Tasks;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    

    [SerializeField] private GameObject _beginText;
    [SerializeField] private GameObject _secondText;
    [SerializeField] private Animator _animator;

    [SerializeField] private Image image;
    [SerializeField] private float duration = 1f;


    [SerializeField] private GameObject _npcPrefab;

    private bool _started =false;
    void Start()
    {
        _beginText.SetActive(true);
        NextText();
        Bacground();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    async UniTask NextText()
    {
        await UniTask.Delay(9000);
        _beginText.SetActive(false);
        _secondText.SetActive(true);
        await UniTask.Delay(9000);
        _secondText.SetActive(false);
        _animator.enabled = true;

        // _animator.enabled = false;
    }

    private async UniTask Bacground()
    {
        await UniTask.Delay(18000);
        Color color = image.color;

        float time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;

            color.a = Mathf.Lerp(2f, 0f, time / duration);
            image.color = color;

            await UniTask.Yield();
        }

        color.a = 0f;
        image.color = color;
        await UniTask.Delay(3000);
        _npcPrefab.SetActive(true);

    }

    
}
