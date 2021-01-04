using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEditor.ProjectWindowCallback;
using UnityEngine;

namespace Cirnoclassroom.UI {

    /// <summary>
    /// 脚本模板创建工具
    /// </summary>
    public class CirnoTemplateTool : MonoBehaviour {

        private const string CIRNOCLASSROOM_SCRIPT_LOCATE = "99-C# Script-NewCirnoclassroomScript.cs.txt";
        private const string CIRNOCLASSROOM_SCRIPT_DEFAULT_FILENAME = "/NewCirnoclassroomScript.cs";

        [MenuItem("Assets/Create/Cirnoclassroom/Template Script", false, 99)]
        private static void CreateCirnoclassroomTemplateScript() {
            ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0,
                ScriptableObject.CreateInstance<CreateScriptAction>(),
                GetSelectedPathOrFallback() + CIRNOCLASSROOM_SCRIPT_DEFAULT_FILENAME,
                null, GetFileFullName(CIRNOCLASSROOM_SCRIPT_LOCATE));
        }

        /// <summary>
        /// 得到选中的路径
        /// </summary>
        /// <returns></returns>
        public static string GetSelectedPathOrFallback() {
            // 默认路径为Assets
            string selectedPath = "Assets";

            // 获取选中的资源
            Object[] selection = Selection.GetFiltered(typeof(Object), SelectionMode.Assets);

            // 遍历选中的资源以返回路径
            foreach (Object obj in selection) {
                selectedPath = AssetDatabase.GetAssetPath(obj);
                if (!string.IsNullOrEmpty(selectedPath) && File.Exists(selectedPath)) {
                    selectedPath = Path.GetDirectoryName(selectedPath);
                    break;
                }
            }

            return selectedPath;
        }

        public static string GetFileFullName(string filename) {
            DirectoryInfo di = new DirectoryInfo(Application.dataPath);
            foreach (var fi in di.GetFiles(filename, SearchOption.AllDirectories)) {
                return fi.FullName;
            }
            return default;
        }

        /// <summary>
        /// 定义一个创建资源的 Action 类并实现其 Action 方法
        /// </summary>
        class CreateScriptAction : EndNameEditAction {

            public override void Action(int instanceId, string pathName, string resourceFile) {
                // 创建资源
                Object obj = CreateScriptAssetFromTemplate(pathName, resourceFile);
                // 高亮显示该资源
                ProjectWindowUtil.ShowCreatedAsset(obj);
            }

            internal static Object CreateScriptAssetFromTemplate(string pathName, string resourceFile) {
                // 获取要创建资源的绝对路径
                string fullPath = Path.GetFullPath(pathName);

                // 读取本地模版文件
                StreamReader streamReader = new StreamReader(resourceFile);
                string text = streamReader.ReadToEnd();
                streamReader.Close();

                // 获取资源的文件名
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(pathName);

                // 替换默认的文件名
                text = Regex.Replace(text, "#SCRIPTNAME#", fileNameWithoutExtension);
                bool encoderShouldEmitUTF8Identifier = true;
                bool throwOnInvalidBytes = false;

                UTF8Encoding encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier, throwOnInvalidBytes);
                bool append = false;

                // 写入新文件
                StreamWriter streamWriter = new StreamWriter(fullPath, append, encoding);
                streamWriter.Write(text);
                streamWriter.Close();

                // 刷新本地资源
                AssetDatabase.ImportAsset(pathName);
                AssetDatabase.Refresh();

                return AssetDatabase.LoadAssetAtPath(pathName, typeof(Object));
            }

        }

    }
}