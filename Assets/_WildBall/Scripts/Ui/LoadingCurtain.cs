using System;
using System.Collections;
using UnityEngine;

namespace Ui
{
    public class LoadingCurtain : MonoBehaviour
    {
        public CanvasGroup Curtain;

        public void Show()
        {
            StopAllCoroutines();
            gameObject.SetActive(true);
            Curtain.alpha = 1;
        }

        public void SmoothShow(Action onShowed = null)
        {
            Curtain.alpha = 0;
            gameObject.SetActive(true);
            
            StartCoroutine(DoFadeOut(onShowed));
        }

        public void Hide() => StartCoroutine(DoFadeIn());

        private IEnumerator DoFadeIn()
        {
            while (Curtain.alpha > 0)
            {
                Curtain.alpha -= 0.03f;
                yield return new WaitForSeconds(0.03f);
            }

            gameObject.SetActive(false);
        }

        private IEnumerator DoFadeOut(Action onShowed = null)
        {
            while (Curtain.alpha < 1)
            {
                Curtain.alpha += 0.03f;
                yield return new WaitForSeconds(0.03f);
            }

            onShowed?.Invoke();
        }
    }
}