using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV.Util;
using System.Windows;

namespace TCMAssistant.Service
{
    public class HSV : IAssistant
    {
        public HSV() { }
        public HSV(float h, float s, float v)
        {
            H = h;
            S = s;
            V = v;
        }

        /// <summary>
        /// 色相
        /// </summary>
        public double H { get; set; } = 0;
        /// <summary>
        /// 饱和度
        /// </summary>
        public double S { get; set; } = 0;
        /// <summary>
        /// 亮度
        /// </summary>
        public double V { get; set; } = 0;

        public object HSVAssistant(HSV value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 返回一个HSV均值
        /// </summary>
        public static HSV Parse(Mat srcMat)
        {
            Mat tempMat = srcMat.Clone();
            Mat hsvMat = new Mat();
            CvInvoke.CvtColor(tempMat, hsvMat, Emgu.CV.CvEnum.ColorConversion.Bgr2Hsv);
            Mat[] channels = hsvMat.Split();
            var result = new HSV();
            result.H = CvInvoke.Mean(channels[0]).V0;
            result.S = CvInvoke.Mean(channels[1]).V0;
            result.V = CvInvoke.Mean(channels[2]).V0;
            return result;
        }
    }
}
