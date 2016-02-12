using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace VideoDemonstration
{
	public class VideoDemonstrationController : AbstactSceneController<VideoDemonstrationController>
	{
		public static int VideoId = 0;
		[SerializeField] private RawImage _videoScreen;
		[SerializeField] private AudioSource _audioSource;
		[SerializeField] private List<VideoClip> _clips = new List<VideoClip>();
		private MovieTexture _currentClip;

		protected override void OnAwake()
		{
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
				_currentClip.Play();
				_audioSource.Play();
			}
		}

		public void Stop()
		{
			if(_currentClip==null)
				return;

			if(_currentClip.isPlaying)
			{
				_currentClip.Stop();
				_audioSource.Stop();
			}
		}

		public void Pause()
		{
			if(_currentClip==null)
				return;

			if(_currentClip.isPlaying)
			{
				_currentClip.Pause();
				_audioSource.Pause();
			}
		}
	}
}
