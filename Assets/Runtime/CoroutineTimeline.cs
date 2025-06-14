using System.Collections.Generic;
using UnityEngine;

namespace JinToliq.SimpleTween
{
  public static class CoroutineTimeline
  {
    public static IEnumerable<float> DoLinear(float time)
    {
      var currentTime = 0f;
      while ((currentTime += Time.deltaTime) < time)
        yield return currentTime / time;

      yield return 1;
    }

    public static IEnumerable<float> DoLinearReverse(float time)
    {
      var currentTime = 0f;
      while ((currentTime += Time.deltaTime) < time)
        yield return 1f - currentTime / time;

      yield return 0;
    }
  }
}