using UnityEngine;
using System.Collections;

namespace MenuLearning
{
	public class MenuLearningChooseModeButton : MenuLearningChangeStateButton
	{
		[SerializeField] private MenuLearningMode _mode;

		protected override void ButtonClick()
		{
			MenuLearningSceneController.Instance.Mode = _mode;
			base.ButtonClick();
		}
	}
}
