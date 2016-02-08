using UnityEngine;
using System.Collections;

namespace LearningComponents
{
	public class SceneModelComponent : BaseSceneModel
	{
		[SerializeField] private int _componentId;

		public override void Click()
		{
			GasMaskComponentsSceneController.Instance.ChooseComponent(_componentId);
		}
	}
}
