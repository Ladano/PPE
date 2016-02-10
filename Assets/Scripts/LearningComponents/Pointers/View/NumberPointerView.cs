using UnityEngine;
using System.Collections;

namespace LearningComponents
{
	[System.Serializable]
	public class NumberPointerView : BasePointerView
	{
		public TextMesh TextNumber;

		public override void ChangeAlpha(float alpha)
		{
			TextNumber.color = new Color(TextNumber.color.r,
			                             TextNumber.color.g,
			                             TextNumber.color.b,
			                             alpha);
		}

		public override void OnUpdate()
		{
			TextNumber.transform.LookAt(TextNumber.transform.position + Camera.main.transform.rotation * Vector3.forward,
			                            Camera.main.transform.rotation * Vector3.up);
		}
	}
}
