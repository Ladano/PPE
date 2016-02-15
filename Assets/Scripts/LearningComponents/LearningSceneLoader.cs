using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace LearningComponents
{
	public class LearningSceneLoader : AbstactSceneController<LearningSceneLoader>
	{
		private const string ConfigFilePath = "ItemsConfig";

		public static TypeOfPPE TypePPE = TypeOfPPE.gasMask;

		[SerializeField] private Transform _item;
		[SerializeField] private ItemMoveController _itemMoveController;
		[SerializeField] private PointersSceneController _pointersSceneController;
		private ItemConfig _currentItemConfig;

		protected override void OnAwake()
		{
			_currentItemConfig = LoadConfig();
			if(_currentItemConfig!=null)
			{
				LoadItem();
				_itemMoveController.Init(_currentItemConfig.ItemMinXRotation, _currentItemConfig.ItemMaxXRotation);
				_pointersSceneController.Init(_currentItemConfig.ItemComponentsResourcesPath);
			}
			else
			{
				Debug.LogException(new System.Exception("Не загружен предмет с TypeOfPPE = " + TypePPE.ToString()));
			}
		}

		private static ItemConfig LoadConfig()
		{
			TextAsset json = Resources.Load(ConfigFilePath) as TextAsset;
			if(json!=null)
			{
				return JsonConvert.DeserializeObject<List<ItemConfig>>(json.text).FirstOrDefault( a => a.TypePPE==TypePPE );
			}
			else
			{
				Debug.LogException(new System.Exception("Потерян конфиг файл ItemsConfig.cfg"));
				return null;
			}
		}

		private void LoadItem()
		{
			GameObject itemModel = Instantiate(Resources.Load(_currentItemConfig.ItemModelResourcesPath)) as GameObject;
			itemModel.transform.parent = _item;

			_item.rotation = Quaternion.Euler(new Vector3(_currentItemConfig.ItemStartRotation,
			                                              _item.rotation.eulerAngles.y,
			                                              _item.rotation.eulerAngles.z));
			itemModel.transform.rotation = Quaternion.Euler(new Vector3(_currentItemConfig.ItemModelStartRotation,
			                                                            itemModel.transform.rotation.eulerAngles.y,
			                                                            itemModel.transform.rotation.eulerAngles.z));
		}
	}
}
