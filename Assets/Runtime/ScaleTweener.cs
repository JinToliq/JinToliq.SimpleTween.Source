using UnityEngine;

namespace JinToliq.SimpleTween
{
  public class ScaleTweener : AnimationCurveTweener<Transform>
  {
    public Vector3 From;
    public Vector3 To;

    protected override void Evaluate(float factor)
    {
      Target.localScale = Vector3.LerpUnclamped(From, To, factor);
    }
  }
}