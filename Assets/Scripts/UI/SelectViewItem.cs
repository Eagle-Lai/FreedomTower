using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace FTProject
{
    public class SelectViewItem : MonoBehaviour
    {
        public Image bg;
        public TextMeshProUGUI _indexTxt;
        public Button btn;
        public TextMeshProUGUI _btnTxt;

        public bool isInit;
        private void Awake()
        {
            isInit = false;
        }

        private void Start()
        {
            bg = transform.Find("Image").GetComponent<Image>();
            _indexTxt = transform.Find("IndexTxt").GetComponent<TextMeshProUGUI>();
            if(btn != null)
            {
                btn.onClick.RemoveAllListeners();
            }
            btn = transform.Find("Button").GetComponent<Button>();
            btn.onClick.AddListener(OnClickButton);
            _btnTxt = transform.Find("Button/Text").GetComponent<TextMeshProUGUI>();
        }

        private void OnClickButton()
        {

        }

        public void Init()
        {
            isInit = true;
        }

        public void SetItemData(BaseGameScene info)
        {
            if(_indexTxt == null)
            {
                Start();
            }
            _indexTxt.text = string.Format("��{0}��", info._SceneInfo.Id);
            _btnTxt.text = string.Format("��{0}��", info._SceneInfo.Id);
        }
    }
}
