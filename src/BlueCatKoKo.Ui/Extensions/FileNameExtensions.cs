using System.IO;
using System.Text;

namespace BlueCatKoKo.Ui.Extensions;

public static class FileNameExtensions
{
    /// <summary>
    /// 替换非法字符
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public static string ReplaceInvalidCharacters(this string fileName)
    {
        var invalidChars = Path.GetInvalidFileNameChars();
        var replacedFileName = new StringBuilder();

        foreach (var c in fileName)
        {
            replacedFileName.Append(!invalidChars.Contains(c) ? c : '#');
        }

        return replacedFileName.ToString();
    }
}