using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
  [SerializeField] private Image m_ForegroundFill;

  public void SetProgress(float progress)
  {
    m_ForegroundFill.fillAmount = Mathf.Clamp01(progress);
  }
}