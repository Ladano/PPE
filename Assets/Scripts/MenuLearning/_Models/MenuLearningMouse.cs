using UnityEngine;
using System.Collections;

namespace MenuLearning
{
	public class MenuLearningMouse : BaseMouseCastController
	{
		public static event System.Action<BaseSceneModel> OnModelFocus;

		protected override void OnUpdate()
		{
			BaseSceneModel model = GetFocusedModel();
			if(OnModelFocus!=null)
			{
				OnModelFocus(model);
			}
			if(model!=null && Input.GetMouseButtonDown(0))
			{
				model.Click();
			}
		}
	}
}
