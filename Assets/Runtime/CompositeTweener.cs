using System;
using System.Collections.Generic;

namespace JinToliq.SimpleTween
{
  public readonly struct CompositeTweener
  {
    private readonly IReadOnlyList<Tweener> _tweeners;
    private readonly Tweener _longest;

    public CompositeTweener(IReadOnlyList<Tweener> tweeners)
    {
      _tweeners = tweeners;
      _longest = null;
      if (_tweeners.Count == 0)
        return;

      _longest = tweeners[0];
      for (var i = 1; i < _tweeners.Count; i++)
      {
        var tweener = _tweeners[i];
        if (tweener.Duration > _longest.Duration)
          _longest = _tweeners[i];
      }
    }

    public void Play(Action onComplete, float speed = 1f)
    {
      if (_tweeners.Count == 0)
      {
        onComplete?.Invoke();
        return;
      }

      foreach (var item in _tweeners)
      {
        if (item == _longest)
          item.Play(speed, onComplete);
        else
          item.Play(speed);
      }
    }

    public void PlayReverse(Action onComplete, float speed = 1f)
    {
      if (_tweeners.Count == 0)
      {
        onComplete?.Invoke();
        return;
      }

      foreach (var item in _tweeners)
      {
        if (item == _longest)
          item.PlayReverse(speed, onComplete);
        else
          item.PlayReverse(speed);
      }
    }

    public void Stop(bool reset)
    {
      if (_tweeners.Count == 0)
        return;

      foreach (var tweener in _tweeners)
        tweener.Stop(reset);
    }
  }
}