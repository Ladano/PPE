using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace MenuLearning
{
	public class MenuLearningModel : MonoBehaviour
	{
		private const float FadeStape = 0.084f;

		[SerializeField] private TypeOfPPE _typeOfPPE;
		[SerializeField] private List<Material> _materials = new List<Material>();
		[SerializeField] private Color _colorUnactive;
		[SerializeField] private Color _colorActive;
		[SerializeField] private SpriteRenderer _sprite;

		private float _currentState;
		private float CurrentState
		{
			get { return _currentState; }
			set { _currentState = Mathf.Clamp(value, 0.0f, 1.0f); }
		}
		private bool _isFocused = false;

		private void OnEnable()
		{
			MenuLearningMouse.OnModelFocus += ModelFocus;
		}

		private void OnDisable()
		{
			MenuLearningMouse.OnModelFocus -= ModelFocus;
		}

		private void ModelFocus(MenuLearningModel model)
		{
			if(model==this)
			{
				_isFocused = true;
			}
			else
			{
				_isFocused = false;
			}
		}

		private void Update()
		{
			if(_isFocused)
			{
				CurrentState += FadeStape;
			}
			else
			{
				CurrentState -= FadeStape;
			}

			Color color = Color.Lerp(_colorUnactive, _colorActive, CurrentState);
			_materials.ForEach( a => a.SetColor("_SpecColor", color) );
			_sprite.color = color;
		}

		public void Click()
		{
			MenuLearningSceneController.Instance.LoadLearning(_typeOfPPE);
		}
	}
}
