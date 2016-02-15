using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace VideoDemonstration
{
	public class VideoDemonstrationController : AbstactSceneController<VideoDemonstrationController>
	{
		public enum VideoState { stoped, played, paused }

		public static event System.Action<VideoState> OnVideoStateChanged;
		public static bool IsFirstStart = false;
		public static int VideoId = 0;
		[SerializeField] private RawImage _videoScreen;
		[SerializeField] private AudioSource _audioSource;
		[SerializeField] private List<VideoClip> _clips = new List<VideoClip>();
		private MovieTexture _currentClip;
		private VideoState _currentState;
		private bool _isPlayed;
		private float _playerTimer;

		protected override void OnAwake()
		{
			InitClip();

			if(IsFirstStart)
			{
				IsFirstStart = false;
				Invoke("Play", 1.0f);
			}
		}

		private void InitClip()
		{
			_currentClip = null;
			_videoScreen.texture = null;
			_audioSource.clip = null;

			VideoClip clip = _clips.FirstOrDefault( a => a.Id==VideoId );
			if(clip!=null)
			{
				_currentClip = clip.Video;
				_videoScreen.texture = clip.Video;
				_audioSource.clip = clip.Audio;
			}
		}

		public void Play()
		{
			if(_currentClip==null)
				return;

			if(!_currentClip.isPlaying && _currentClip.isReadyToPlay)
			{
				_isPlayed = true;
				ChangeVideoState(VideoState.played);
				_currentClip.Play();
				_audioSource.Play();

				if(_currentState==VideoState.stoped)
				{
					_playerTimer = 0.0f;

				}
				Invoke("EndClip", _currentClip.duration - _playerTimer + 0.5f);
			}
		}

		public void Stop()
		{
			if(_currentClip==null)
				return;

			//if(_currentClip.isPlaying)
			//{
				_isPlayed = false;
				ChangeVideoState(VideoState.stoped);
				_currentClip.Stop();
				_audioSource.Stop();
			//}
		}

		public void Pause()
		{
			if(_currentClip==null)
				return;

			if(_currentClip.isPlaying)
			{
				_isPlayed = false;
				ChangeVideoState(VideoState.paused);
				_currentClip.Pause();
				_audioSource.Pause();
				CancelInvoke("EndClip");
			}
		}

		private void EndClip()
		{
			Stop();
			LevelChanger.Instance.StartLoadLevel(LevelsData.LevelsDictionary.CurrentLevel);
		}

		private void Update()
		{
			if(_isPlayed)
			{
				_playerTimer += Time.deltaTime;
			}
		}

		private void ChangeVideoState(VideoState state)
		{
			_currentState = state;
			if(OnVideoStateChanged!=null)
			{
				OnVideoStateChanged(state);
			}
		}
	}
}
