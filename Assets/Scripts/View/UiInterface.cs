using UnityEngine;

namespace Geekbrains
{
    public class UiInterface
    {
        private FlashLightUiText _flashLightUiText;
        public FlashLightUiText LightUiText
        {
            get
            {
                if (!_flashLightUiText)
                    _flashLightUiText = Object.FindObjectOfType<FlashLightUiText>();
                return _flashLightUiText;
            }
        }

        private FlashLightUi_Bar _flashLightUiBar;
        public FlashLightUi_Bar FlashLightUiBar
        {
            get
            {
                if (!_flashLightUiBar)
                    _flashLightUiBar = Object.FindObjectOfType<FlashLightUi_Bar>();
                return _flashLightUiBar;
            }
        }

        private WeaponUiText _weaponUiText;
        public WeaponUiText WeaponUiText
        {
            get
            {
                if (!_weaponUiText)
                    _weaponUiText = Object.FindObjectOfType<WeaponUiText>();
                return _weaponUiText;
            }
        }

        private SelectionObjMessageUi _selectionObjMessageUi;
        public SelectionObjMessageUi SelectionObjMessageUi
        {
            get
            {
                if (!_selectionObjMessageUi)
                    _selectionObjMessageUi = Object.FindObjectOfType<SelectionObjMessageUi>();
                return _selectionObjMessageUi;
            }
        }

        private ScopeUi _scopeUi;
        public ScopeUi ScopeUi
        {
            get
            {
                if (!_scopeUi)
                    _scopeUi = Object.FindObjectOfType<ScopeUi>();
                return _scopeUi;
            }
        }

        private BulletPoolUi _bulletPoolUi;
        public BulletPoolUi BulletPoolUi
        {
            get
            {
                if (!_bulletPoolUi)
                    _bulletPoolUi = Object.FindObjectOfType<BulletPoolUi>();
                return _bulletPoolUi;
            }
        }

        private EnemyUI_Slider[] _enemyUi_Slider;
        public EnemyUI_Slider[] EnemyUi_Slider
        {
            get
            {
                if (_enemyUi_Slider==null)
                    _enemyUi_Slider = Object.FindObjectsOfType<EnemyUI_Slider>();
                return _enemyUi_Slider;
            }
        }
        private EnemyUI_Text[] _enemyUi_Text;
        public EnemyUI_Text[] EnemyUi_Text
        {
            get
            {
                if (_enemyUi_Text==null)
                    _enemyUi_Text = Object.FindObjectsOfType<EnemyUI_Text>();
                return _enemyUi_Text;
            }
        }

        private SelectedItemUI_Text _selectedItemUI_Text;
        public SelectedItemUI_Text SelectedItemUI_Text
        {
            get
            {
                if (!_selectedItemUI_Text)
                    _selectedItemUI_Text = Object.FindObjectOfType<SelectedItemUI_Text>();
                return _selectedItemUI_Text;
            }
        }


        private SelectedWeaponUiImg _selectedWeaponUiImg;
        public SelectedWeaponUiImg SelectedWeaponUiImg
        {
            get
            {
                if (!_selectedWeaponUiImg)
                    _selectedWeaponUiImg = Object.FindObjectOfType<SelectedWeaponUiImg>();
                return _selectedWeaponUiImg;
            }
        }

        private AmmoUiImg _ammoUiImg;
        public AmmoUiImg AmmoUiImg
        {
            get
            {
                if (!_ammoUiImg)
                    _ammoUiImg = Object.FindObjectOfType<AmmoUiImg>();
                return _ammoUiImg;
            }
        }

        private SelectedWeaponUiText _selectedWeaponUiText;
        public SelectedWeaponUiText SelectedWeaponUiText
        {
            get
            {
                if (!_selectedWeaponUiText)
                    _selectedWeaponUiText = Object.FindObjectOfType<SelectedWeaponUiText>();
                return _selectedWeaponUiText;
            }
        }

        private TargetsLeftUi _targetsLeftUi;
        public TargetsLeftUi TargetsLeftUi
        {
            get
            {
                if (!_targetsLeftUi)
                    _targetsLeftUi = Object.FindObjectOfType<TargetsLeftUi>();
                return _targetsLeftUi;
            }
        }
        





    }
}
