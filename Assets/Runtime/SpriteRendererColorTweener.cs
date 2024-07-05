using UnityEngine;

namespace JinToliq.SimpleTween
{
  public class SpriteRendererColorTweener : AnimationCurveTweener<SpriteRenderer>
  {
    public Color From;
    public Color To;

    protected override void Evaluate(float factor)
    {
      Target.color = Color.Lerp(From, To, factor);
    }

    private void Reset()
    {
      Target = GetComponent<SpriteRenderer>();
      if (Target is null)
        From = To = Color.white;
      else
        From = To = Target.color;
    }
  }
}