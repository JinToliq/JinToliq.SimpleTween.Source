using UnityEngine;
using UnityEngine.UI;

namespace JinToliq.SimpleTween
{
  public class ColorTweener : AnimationCurveTweener<Graphic>
  {
    public Color From;
    public Color To;

    protected override void Evaluate(float factor)
    {
      Target.color = Color.Lerp(From, To, factor);
    }
  }
}