namespace Cirnoclassroom.UI {
    /// <summary>
    /// 用于框架定义常量、全局性方法、枚举类型、委托定义
    /// </summary>
    public class UIDefine {

        #region Variables

        #region Enum

        /// <summary>
        /// 面板显示类型
        /// </summary>
        public enum TransformType {
            /// <summary>
            /// 普通
            /// </summary>
            Normal,
            /// <summary>
            /// 固定
            /// </summary>
            Fixed,
            /// <summary>
            /// 弹窗
            /// </summary>
            Popup,
        }

        /// <summary>
        /// 面板显示模式
        /// </summary>
        public enum DisplayMode {
            /// <summary>
            /// 正常显示面板
            /// </summary>
            Normal,
            /// <summary>
            /// 顺序显示面板
            /// </summary>
            Sequence,
            /// <summary>
            /// 仅显示当前面板
            /// </summary>
            Alone,
        }

        /// <summary>
        /// 面板透明度类型
        /// </summary>
        public enum AlphaType {
            /// <summary>
            /// 完全透明，不可穿透
            /// </summary>
            Transparent,
            /// <summary>
            /// 半透明，不可穿透
            /// </summary>
            Translucent,
            /// <summary>
            /// 低透明，不可穿透
            /// </summary>
            LowTransparent,
            /// <summary>
            /// 可穿透
            /// </summary>
            Penetrable,
        }

        #endregion

        #endregion

    }
}
