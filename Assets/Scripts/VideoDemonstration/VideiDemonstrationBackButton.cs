using UnityEngine;
using System.Collections;

namespace VideoDemonstration
{
	public class VideiDemonstrationBackButton : LevelChangerButton
	{
		protected override void StartLoadLevel()
		{
			VideoDemonstrationController.Instance.Stop();
			base.StartLoadLevel();
		}
	}
}
