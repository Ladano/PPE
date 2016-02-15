using UnityEngine;
using System.Collections;

namespace VideoDemonstration
{
	public class VideoDemonstrationStopButton : AbstractButton
	{
		protected override void ButtonClick()
		{
			VideoDemonstrationController.Instance.Stop();
		}
	}
}
