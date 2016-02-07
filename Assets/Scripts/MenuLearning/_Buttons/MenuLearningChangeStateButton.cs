using UnityEngine;
using System.Collections;

namespace MenuLearning
{
	public class MenuLearningChangeStateButton : AbstractButton
	{
		[SerializeField] private MenuLearningSceneState _state;
		
		protected override void ButtonClick()
		{
			MenuLearningSceneController.Instance.SetSceneState(_state);
		}
	}
}
