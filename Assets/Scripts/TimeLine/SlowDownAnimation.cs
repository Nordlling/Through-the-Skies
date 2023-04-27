using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class SlowDownAnimation : MonoBehaviour
{
    public PlayableDirector timeline;
    public AnimationClip clipToSlowDown;
    public float slowdownRate = 0.1f;

    private Animation _animation;

    private void Start()
    {
        _animation = GetComponent<Animation>();
        timeline.played += OnTimelinePlayed;
    }

    private void OnTimelinePlayed(PlayableDirector director)
    {
        if (director.state == PlayState.Playing && director.playableAsset == timeline.playableAsset)
        {
            if (_animation.clip == clipToSlowDown)
            {
                StartCoroutine(SlowDownAnimationCoroutine());
            }
        }
    }

    private IEnumerator SlowDownAnimationCoroutine()
    {
        while (_animation[clipToSlowDown.name].speed > 0.01f)
        {
            _animation[clipToSlowDown.name].speed -= slowdownRate;
            yield return new WaitForEndOfFrame();
        }
        _animation[clipToSlowDown.name].speed = 0f;
    }
}