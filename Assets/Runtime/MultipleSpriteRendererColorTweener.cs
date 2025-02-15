using UnityEngine;

namespace JinToliq.SimpleTween
{
  public class MultipleSpriteRendererColorTweener : MultipleAnimationCurveTweener<SpriteRenderer>
  {
    public Color From;
    public Color To;

    protected override void Evaluate(float factor)
    {
      ForEach((r, c) => r.color = c, Color.Lerp(From, To, factor));
    }

    private void Reset()
    {
      Target = GetComponents<SpriteRenderer>();
      From = To = Color.white;
    }
  }
}