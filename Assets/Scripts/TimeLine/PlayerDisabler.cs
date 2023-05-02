using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Zenject;

public class PlayerDisabler : MonoBehaviour
{
    [Inject] private PlayerMovement _player;
    public PlayableDirector timeline;

    private void Start()
    {
        if (timeline != null)
        {
            timeline.played += OnTimelineStart;
            timeline.stopped += OnTimelineStop;
            if (timeline.playOnAwake)
            {
                _player.enabled = false; 
            }
        }
    }

    private void OnTimelineStart(PlayableDirector director)
    {
        _player.enabled = false;
    }

    private void OnTimelineStop(PlayableDirector director)
    {
        _player.enabled = true;
    }
}
