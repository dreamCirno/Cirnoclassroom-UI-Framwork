using UnityEngine;

namespace Cirnoclassroom.UI {
    /// <summary>
    /// 面板基类
    /// </summary>
    public class BasePanel : MonoBehaviour {

        #region Variables



        #endregion

        #region MainMethods

        /// <summary>
        /// 当显示面板时触发
        /// </summary>
        protected virtual void OnPanelEnter() {

        }

        /// <summary>
        /// 当面板显示时每帧触发
        /// </summary>
        protected virtual void OnPanelUpdate() {

        }

        /// <summary>
        /// 当面板的激活状态切换至其他面板时触发
        /// </summary>
        protected virtual void OnPanelPause() {

        }

        /// <summary>
        /// 当面板恢复激活状态时触发
        /// </summary>
        protected virtual void OnPanelResume() {

        }

        /// <summary>
        /// 当关闭面板时触发
        /// </summary>
        protected virtual void OnPanelExit() {

        }

        #endregion

        #region HelperMethods



        #endregion

    }
}
