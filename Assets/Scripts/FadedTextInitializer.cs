using UnityEngine;

namespace Assets.Scripts
{
    public class FadedTextInitializer : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {
            var fadedText = GetComponent<CanvasGroup>();
            fadedText.alpha = 0;
        }
    }
}