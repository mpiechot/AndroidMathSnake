#nullable enable

using Cysharp.Threading.Tasks;
using MathSnake.Assets.MathSnake.Util;
using MathSnake.Exceptions;
using System;
using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

namespace MathSnake.Eatables.States
{
    public sealed class Rotting : MonoBehaviour, IDisposable
    {
        [SerializeField]
        private AudioSource? splashSound;

        [SerializeField]
        private bool isRotting;

        [SerializeField]
        private Image? rottingBar;

        [SerializeField]
        private Canvas? rottingCanvas;

        private CancellableTaskCollection cancellableTaskCollection = new();

        private EatableSettings? rottingSettings;

        private float currentRotTime;
        private bool disposedValue;

        private EatableSettings RottingSettings => NotInitializedException.ThrowIfNull(rottingSettings);

        private Image RottingBar => SerializeFieldNotAssignedException.ThrowIfNull(rottingBar);

        private Canvas RottingCanvas => SerializeFieldNotAssignedException.ThrowIfNull(rottingCanvas);

        private AudioSource SplashSound => SerializeFieldNotAssignedException.ThrowIfNull(splashSound);

        /// <summary>
        ///    Initializes a new instance of the <see cref="Rotting"/> class.
        /// </summary>
        /// <param name="rottingSettings">The rotting settings to use.</param>
        public void Initialize(EatableSettings rottingSettings)
        {
            this.rottingSettings = rottingSettings;
        }

        /// <summary>
        ///     Starts the rotting process.
        /// </summary>
        public void StartRotting()
        {
            if (isRotting)
            {
                return;
            }

            RottingBar.fillAmount = currentRotTime;
            RottingBar.color = rottingSettings!.FreshColor;
            RottingCanvas.enabled = true;
            RottingCanvas.gameObject.SetActive(true);

            isRotting = true;
            cancellableTaskCollection.StartExecution(Rot);
        }

        private async UniTask Rot(CancellationToken cancellationToken)
        {
            currentRotTime = 1;
            while (currentRotTime > 0)
            {
                await UniTask.NextFrame(cancellationToken);

                currentRotTime -= RottingSettings.RottingSpeed;
                RottingBar.fillAmount = currentRotTime;

                transform.localScale = Vector3.one * Mathf.Lerp(RottingSettings.FreshSize, RottingSettings.DeadSize, 1 - currentRotTime);

                if (currentRotTime < .33f)
                {
                    RottingBar.color = RottingSettings.DeadColor;
                }
                else if (currentRotTime < .66f)
                {
                    RottingBar.color = RottingSettings.GoodColor;
                }
            }

            SplashSound.Play();

            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            Dispose();
        }

        private void Dispose(bool disposing)
        {
            if (disposedValue || !disposing)
            {
                return;
            }

            cancellableTaskCollection.Dispose();
            cancellableTaskCollection = null!;


            disposedValue = true;
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
