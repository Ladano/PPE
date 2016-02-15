using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace LearningComponents
{
	public class ModelColorController : MonoBehaviour
	{
		[SerializeField] private int _id;
		[SerializeField] private List<Renderer> _renderers;
		[SerializeField] private bool _isNotRotated = false;

		private void OnEnable()
		{
			PointersSceneController.OnComponentChoose += ChangeColor;
		}

		private void OnDisable()
		{
			PointersSceneController.OnComponentChoose -= ChangeColor;
		}

		private void Awake()
		{
			if(_isNotRotated)
			{
				transform.parent = GameObject.FindGameObjectWithTag("3DObjectsRoot").transform;
			}
		}

		private void ChangeColor(int id)
		{
			_renderers.ForEach( a => a.material.SetColor("_node_36", (_id==id) ? PointersSceneController.Instance.ColorActive : PointersSceneController.Instance.ColorUnactive) );
		}
	}
}
