using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace MenuLearning
{
	public class MenuLearningSceneController : AbstactSceneController<MenuLearningSceneController>
	{
		[HideInInspector] public MenuLearningMode Mode;

		[SerializeField] private List<MenuLearningModelData> _models = new List<MenuLearningModelData>();
		[SerializeField] private List<AbstractButton> _buttons = new List<AbstractButton>();
		[SerializeField] private AbstractButton _backButton;
		[SerializeField] private MenuLearningMouse _mouseController;
		private MenuLearningSceneState _currentSceneState = MenuLearningSceneState.menu;

		protected override void OnAwake()
		{
			_models.ForEach( a => a.Model.transform.position = a.SideWp.position );
		}

		public void SetSceneState(MenuLearningSceneState newState)
		{
			if(newState==_currentSceneState)
				return;

			_currentSceneState = newState;
			switch(_currentSceneState)
			{
			case MenuLearningSceneState.menu:
				_buttons.ForEach( a => a.Show(0.2f) );
				_backButton.Hide(0.2f);
				_mouseController.IsActive = false;
				_models.ForEach( a => LeanTween.move(a.Model, a.SideWp.position, 0.4f) );
				break;
			case MenuLearningSceneState.choosePPE:
				_buttons.ForEach( a => a.Hide(0.2f) );
				_backButton.Show(0.2f);
				_mouseController.IsActive = true;
				_models.ForEach( a => LeanTween.move(a.Model, a.CenterWp.position, 0.4f) );
				break;
			}
		}

		public void LoadLearning(TypeOfPPE typeOfPPE)
		{
			switch(Mode)
			{
			case MenuLearningMode.componentsPPE:
				if(typeOfPPE==TypeOfPPE.gasMask)
				{
					LevelChanger.Instance.StartLoadLevel(LevelId.GasMaskComponents);
				}
				else
				{
					LevelChanger.Instance.StartLoadLevel(LevelId.ProtectiveSuitComponents);
				}
				break;
			}
		}
	}

	[System.Serializable]
	public struct MenuLearningModelData
	{
		public GameObject Model;
		public Transform SideWp;
		public Transform CenterWp;
	}
}
