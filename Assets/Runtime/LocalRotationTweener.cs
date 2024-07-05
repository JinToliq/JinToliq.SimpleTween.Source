using UnityEngine;

namespace JinToliq.SimpleTween
{
  public class LocalRotationTweener : AnimationCurveTweener<Transform>
  {
    public Vector3 From;
    public Vector3 To;

    private Quaternion _from;
    private Quaternion _to;

    protected override void OnBeforePlay()
    {
      _from = Quaternion.Euler(From);
      _to = Quaternion.Euler(To);
    }

    protected override void Evaluate(float factor)
    {
      Target.localRotation = Quaternion.Lerp(_from, _to, factor);
    }
  }
}