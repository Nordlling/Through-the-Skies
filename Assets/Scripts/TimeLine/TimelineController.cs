using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour
{
    public PlayableDirector timeline;
    public AnimatorController animator;
    public AnimationClip animationClip;

    private bool _playAnimation;

    private void Update()
    {
        if (Input.anyKeyDown && !_playAnimation)
        {
            _playAnimation = true;
            // animationClip.Play(animationClip);
        }

        if (_playAnimation && timeline.state == PlayState.Paused)
        {
            timeline.Stop();
            Destroy(gameObject);
        }
    }
}