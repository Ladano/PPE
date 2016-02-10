using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine.UI;

namespace LearningComponents
{
	public class PointersSceneController : AbstactSceneController<PointersSceneController>
	{
		[SerializeField] private Text _labelCommonInfo;
		[SerializeField] private Text _labelComponentTitle;
		[SerializeField] private Text _labelComponentDescription;
		private ItemComponentsData _itemData;

		public void Init(string resourcesPath)
		{
			_itemData = LoadComponents(resourcesPath);
			_labelCommonInfo.text = _itemData.CommonInfo;
		}

		private ItemComponentsData LoadComponents(string resourcesPath)
		{
			TextAsset json = Resources.Load(resourcesPath) as TextAsset;
			if(json!=null)
			{
				return JsonConvert.DeserializeObject<ItemComponentsData>(json.text);
			}
			return null;
		}

		public void ChooseComponent(int id)
		{
			ComponentData data = _itemData.ComponentsInfo.FirstOrDefault( a => a.ComponentId==id );
			if(data!=null)
			{
				_labelComponentTitle.text = data.ComponentTitle;
				_labelComponentDescription.text = data.ComponentDescription;
			}
			else
			{
				_labelComponentTitle.text = "";
				_labelComponentDescription.text = "";
			}
		}
	}
}
