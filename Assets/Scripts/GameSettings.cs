using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace AlexzanderCowell
{
    public class GameSettings : MonoBehaviour
    {
        public int FramesPerSec { get; protected set; }
        [SerializeField] private float frequency = 0.5f;
        [SerializeField] private Text counter;


        private void Start()
        {
            counter.text = "";
            StartCoroutine(FPS());
            Application.targetFrameRate = 60;
        }

        private IEnumerator FPS()
        {
            for (;;)
            {
                int lastFrameCount = Time.frameCount;
                float lastTime = Time.realtimeSinceStartup;
                yield return new WaitForSeconds(frequency);

                float timeSpan = Time.realtimeSinceStartup - lastTime;
                int frameCount = Time.frameCount - lastFrameCount;

                FramesPerSec = Mathf.RoundToInt(frameCount / timeSpan);
                counter.text = "FPS: " + FramesPerSec.ToString();

            }
        }
    } 
}
    
