using TMPro;
using UnityEngine;

namespace UI
{
    public class Timer: MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;

        public float time;
        public bool isTimerGo = false;

        public void TickTimer()
        {
            if (!isTimerGo) return;
            time -= Time.deltaTime;
            text.text = Mathf.Round(time).ToString();
        }

        public void Refresh()
        {
            time = 20;
        }
    }
}