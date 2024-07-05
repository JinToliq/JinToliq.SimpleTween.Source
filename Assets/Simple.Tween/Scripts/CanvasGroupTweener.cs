using UnityEngine;

namespace Simple.Tween
{
  public class CanvasGroupTweener : AnimationCurveTweener<CanvasGroup>
  {
    public float AlphaFrom = 0;
    public float AlphaTo = 1;

    protected override void Evaluate(float factor)
    {
      Target.alpha = Mathf.Lerp(AlphaFrom, AlphaTo, factor);
    }

    private void Reset()
    {
      Target = GetComponent<CanvasGroup>();
    }
  }
}