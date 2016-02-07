using UnityEngine;
using System.Collections;

namespace MenuLearning
{
	public class MenuLearningMouse : MonoBehaviour
	{
		public static event System.Action<MenuLearningModel> OnModelFocus;

		[SerializeField] private Camera _camera;
		public bool IsActive = false;

		private void Update()
		{
			if(IsActive)
			{
				MenuLearningModel model = GetFocusedModel();
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

		private MenuLearningModel GetFocusedModel()
		{
			Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit))
			{
				return hit.collider.gameObject.GetComponent<MenuLearningModel>();
			}
			return null;
		}
	}
}
