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

        public object Assistant()
        {
            var result = string.Empty;

            if (H > 100 && H < 120)
            {
                result += "气血瘀滞 ";
            }
            else if (H > 120)
            {
                result += "气血虚 （或有淤血）";
            }
            else if (H < 75)
            {
                result += "气虚 ";
            }

            if (S > 84 && S < 120)
            {
                result += "";
            }
            else if (S <= 84 && S > 40)
            {
                result += " ";
            }

            if (V > 205 && V <= 230)
            {
                result += "阳虚";
            }
            else if (V > 230)
            {
                result += "火旺";
            }

            return result;
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
