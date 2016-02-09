using UnityEngine;
using System.Collections;

namespace LearningComponents
{
	[System.Serializable]
	public class LinePointerView : BasePointerView
	{
		private readonly Color LineColor = Color.green;

		public LineRenderer Line;
		public Transform StartLineWp;
		public Transform EndLineWp;

		public override void ChangeAlpha(float alpha)
		{
			Color color = new Color(LineColor.r, LineColor.g, LineColor.b, alpha);
			Line.SetColors(color, color);
		}

		public override void OnUpdate()
		{
			Line.SetPosition(0, new Vector3(StartLineWp.position.x, StartLineWp.position.y, StartLineWp.position.z));
			Line.SetPosition(1, new Vector3(EndLineWp.position.x, EndLineWp.position.y, EndLineWp.position.z));
		}
	}
}
