using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine.UI;

namespace LearningComponents
{
	public class GasMaskComponentsSceneController : AbstactSceneController<GasMaskComponentsSceneController>
	{
		[SerializeField] private Text _labelTitle;
		[SerializeField] private Text _labelDescription;
		private List<ComponentData> _components = new List<ComponentData>();

		protected override void OnAwake()
		{
			_components = LoadComponents();
		}

		private static 	List<ComponentData> LoadComponents()
		{
			TextAsset json = Resources.Load("GasMaskComponents") as TextAsset;
			if(json!=null)
			{
				return JsonConvert.DeserializeObject<List<ComponentData>>(json.text);
			}
			return new List<ComponentData>();
		}

		public void ChooseComponent(int id)
		{
			ComponentData data = _components.FirstOrDefault( a => a.ComponentId==id );
			if(data!=null)
			{
				_labelTitle.text = data.ComponentTitle;
				_labelDescription.text = data.ComponentDescription;
			}
			else
			{
				_labelTitle.text = "";
				_labelDescription.text = "";
			}
		}
	}
}
