using System.IO;
using UnityEngine;

namespace Cirnoclassroom.UI {
    /// <summary>
    /// 文件处理工具
    /// </summary>
    public class FileUtil {

        #region Variables



        #endregion

        #region MainMethods



        #endregion

        #region HelperMethods

        /// <summary>
        /// 根据文件名搜索，获取文件路径
        /// </summary>
        /// <param name="filename">文件名称（含后缀）</param>
        /// <returns></returns>
        public static string GetFileFullName(string filename) {
            DirectoryInfo di = new DirectoryInfo(Application.dataPath);
            foreach (var fi in di.GetFiles(filename, SearchOption.AllDirectories)) {
                return fi.FullName;
            }
            return default;
        }

        #endregion

    }
}
