#nullable enable

using MathSnake.Exceptions;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace MathSnake.Eatables.States
{
    public class Rotting : MonoBehaviour
    {
        [SerializeField]
        private bool isRotting;

        [SerializeField]
        private Image? rottingBar;

        [SerializeField]
        private Canvas? rottingCanvas;

        private EatableSettings? rottingSettings;

        private float currentRotTime;

        private Coroutine? rottingCoroutine;

        private EatableSettings RottingSettings => NotInitializedException.ThrowIfNull(rottingSettings);

        private Image RottingBar => SerializeFieldNotAssignedException.ThrowIfNull(rottingBar);

        private Canvas RottingCanvas => SerializeFieldNotAssignedException.ThrowIfNull(rottingCanvas);

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
            rottingCoroutine = StartCoroutine(Rot());
        }

        private IEnumerator Rot()
        {
            currentRotTime = 1;
            while (currentRotTime > 0)
            {
                yield return null;
                currentRotTime -= RottingSettings.RottingSpeed;
                RottingBar.fillAmount = currentRotTime;
                transform.localScale = Vector3.one * Mathf.Lerp(RottingSettings.FreshSize, RottingSettings.DeadSize, 1 - currentRotTime);
                if (currentRotTime < .66f)
                {
                    RottingBar.color = Color.yellow;
                }
                else if (currentRotTime < .33f)
                {
                    RottingBar.color = Color.red;
                }
            }
            //FindObjectOfType<AudioManager>().Play("Splash");
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            if (rottingCoroutine != null)
            {
                StopCoroutine(rottingCoroutine);
            }
        }
    }
}
