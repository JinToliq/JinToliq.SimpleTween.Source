using System;
using UnityEngine;

namespace JinToliq.SimpleTween
{
  public abstract class TargetTweener<T> : Tweener where T : Component
  {
    public T Target;

    protected virtual void Awake() => Target ??= GetComponent<T>();
  }

  public abstract class MultipleTargetTweener<T> : Tweener where T : Component
  {
    public T[] Target;

    protected virtual void Awake() => Target ??= GetComponents<T>();

    protected void ForEach<TArg>(Action<T, TArg> action, TArg arg)
    {
      foreach (var item in Target)
        action(item, arg);
    }
  }
}