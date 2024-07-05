using System;
using System.Collections;
using UnityEngine;

namespace JinToliq.SimpleTween
{
  public enum PlayMode
  {
    ByDemand = 0,
    OnStart = 1,
    OnEnable = 2,
  }

  public abstract class Tweener : MonoBehaviour
  {
    public event Action Complete;
    public event Action ReverseComplete;

    [SerializeField] private PlayMode _mode;
    [SerializeField] private bool _resetOnDisable;
    [SerializeField] private bool _loop;
    public float Duration;
    private Coroutine _routine;

    private void Start()
    {
      if (_mode == PlayMode.OnStart)
        Play();
    }

    private void OnEnable()
    {
      if (_mode == PlayMode.OnEnable)
        Play();
    }

    private void OnDisable()
    {
      if (_resetOnDisable)
        Tween(0);
    }

    public void SetTweenPosition(float value) => Tween(value);

    public void Play(Action onComplete = null)
    {
      if (_routine != null)
        StopCoroutine(_routine);

      _routine = StartCoroutine(Routine(onComplete));
    }

    public void PlayReverse(Action onComplete = null)
    {
      if (_routine != null)
        StopCoroutine(_routine);

      _routine = StartCoroutine(ReverseRoutine(onComplete));
    }

    public void Stop(bool reset)
    {
      if (_routine != null)
        StopCoroutine(_routine);

      if (reset)
        SetTweenPosition(0);
    }

    protected virtual void OnBeforePlay() {}

    protected abstract void Tween(float factor);

    private IEnumerator Routine(Action onComplete = null)
    {
      OnBeforePlay();
      Tween(0);
      var time = 0f;
      while ((time += Time.deltaTime) < Duration)
      {
        Tween(time / Duration);
        yield return null;
      }
      Tween(1);
      Complete?.Invoke();
      onComplete?.Invoke();

      if (_loop)
      {
        yield return null;
        _routine = StartCoroutine(Routine(onComplete));
      }
      else
      {
        _routine = null;
      }
    }

    private IEnumerator ReverseRoutine(Action onComplete = null)
    {
      OnBeforePlay();
      Tween(1);
      var time = Duration;
      while ((time -= Time.deltaTime) > 0)
      {
        Tween(time / Duration);
        yield return null;
      }

      Tween(0);
      ReverseComplete?.Invoke();
      onComplete?.Invoke();
      _routine = null;

      if (_loop)
      {
        yield return null;
        _routine = StartCoroutine(ReverseRoutine(onComplete));
      }
      else
      {
        _routine = null;
      }
    }
  }
}