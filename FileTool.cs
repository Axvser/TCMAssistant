using Microsoft.Win32;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace OpenCVSharpDemo
{
    public static class FileTool
    {
        /// <summary>
        /// 选择指定的图像文件
        /// </summary>
        /// <returns>Mat? 原始图像</returns>
        public static Mat? ImageRead()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "选择图片|*.jpg;*.png;*.jpej;*.webp";
            if (openFileDialog.ShowDialog() == true)
            {
                Mat result = new Mat();
                result = CvInvoke.Imread(openFileDialog.FileName);
                return result;
            }
            return null;
        }

        /// <summary>
        /// 选择指定的图像文件
        /// </summary>
        /// <returns>Mat? 可选图像（Color、Gray、Binary）</returns>
        public static Mat? ImageRead(ImreadModes mode)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "选择图片|*.jpg;*.png;*.jpej;*.webp";
            if (openFileDialog.ShowDialog() == true)
            {
                Mat result = new Mat();
                result = CvInvoke.Imread(openFileDialog.FileName, mode);
                return result;
            }
            return null;
        }
    }
}
