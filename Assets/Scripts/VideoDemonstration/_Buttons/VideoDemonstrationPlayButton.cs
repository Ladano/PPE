using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace VideoDemonstration
{
	public class VideoDemonstrationPlayButton : AbstractButton
	{
		private const string PlayLabel = "Воспроизвести";
		private const string PauseLabel = "Пауза";

		[SerializeField] private Text _buttonLabel;
		private VideoDemonstrationController.VideoState _currentState = VideoDemonstrationController.VideoState.stoped;

		private void Awake()
		{
			_buttonLabel.text = PlayLabel;
		}

		private void OnEnable()
		{
			VideoDemonstrationController.OnVideoStateChanged += StateChanged;
		}

		private void OnDisable()
		{
			VideoDemonstrationController.OnVideoStateChanged -= StateChanged;
		}

		private void StateChanged(VideoDemonstrationController.VideoState state)
		{
			_currentState = state;
			switch(_currentState)
			{
			case VideoDemonstrationController.VideoState.paused:
			case VideoDemonstrationController.VideoState.stoped:
				_buttonLabel.text = PlayLabel;
				break;
			case VideoDemonstrationController.VideoState.played:
				_buttonLabel.text = PauseLabel;
				break;
			}
		}

		protected override void ButtonClick()
		{
			switch(_currentState)
			{
			case VideoDemonstrationController.VideoState.paused:
			case VideoDemonstrationController.VideoState.stoped:
				VideoDemonstrationController.Instance.Play();
				break;
			case VideoDemonstrationController.VideoState.played:
				VideoDemonstrationController.Instance.Pause();
				break;
			}
		}
	}
}
