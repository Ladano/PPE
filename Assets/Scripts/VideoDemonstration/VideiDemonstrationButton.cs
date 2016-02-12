using UnityEngine;
using System.Collections;

namespace VideoDemonstration
{
	public class VideiDemonstrationButton : AbstractButton
	{
		private enum ButtonType { play, stop, pause }

		[SerializeField] private ButtonType _buttonType;

		protected override void ButtonClick()
		{
			switch(_buttonType)
			{
			case ButtonType.play:
				VideoDemonstrationController.Instance.Play();
				break;
			case ButtonType.stop:
				VideoDemonstrationController.Instance.Stop();
				break;
			case ButtonType.pause:
				VideoDemonstrationController.Instance.Pause();
				break;
			}
		}
	}
}
