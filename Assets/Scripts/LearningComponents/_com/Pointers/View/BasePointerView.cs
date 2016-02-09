using UnityEngine;
using System.Collections;

namespace LearningComponents
{
	[System.Serializable]
	public class BasePointerView
	{
		public virtual void ChangeAlpha(float alpha) { }

		public virtual void OnUpdate() { }
	}
}
