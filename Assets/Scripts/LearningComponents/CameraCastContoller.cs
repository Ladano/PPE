using UnityEngine;
using System.Collections;

namespace LearningComponents
{
	public class CameraCastContoller : BaseMouseCastController
	{
		protected override void OnUpdate()
		{
			if(Input.GetMouseButtonDown(0))
			{
				BaseSceneModel model = GetFocusedModel();
				if(model!=null)
				{
					model.Click();
				}
			}
		}
	}
}
