using UnityEngine;

namespace JinToliq.SimpleTween
{
  public abstract class AnimationCurveTweener<T> : TargetTweener<T> where T : Component
  {
    public AnimationCurve Animation = AnimationCurve.Linear(0, 0, 1, 1);

    protected sealed override void Tween(float factor)
    {
      Evaluate(Animation.Evaluate(factor));
    }

    protected abstract void Evaluate(float factor);
  }
}