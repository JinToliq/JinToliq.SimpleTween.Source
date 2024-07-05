using UnityEngine;

namespace Simple.Tween
{
  public abstract class TargetTweener<T> : Tweener where T : Component
  {
    public T Target;

    private void Awake()
    {
      Target ??= GetComponent<T>();
    }
  }
}