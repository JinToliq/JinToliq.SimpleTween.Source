using UnityEngine;

namespace Simple.Tween
{
  public class LocalPositionTweener : AnimationCurveTweener<Transform>
  {
    public Vector3 From;
    public Vector2 To;

    protected override void Evaluate(float factor)
    {
      Target.localPosition = Vector3.LerpUnclamped(From, To, factor);
    }
  }
}