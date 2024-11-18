using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public float H { get; set; } = 0f;
        /// <summary>
        /// 饱和度
        /// </summary>
        public float S { get; set; } = 0f;
        /// <summary>
        /// 亮度
        /// </summary>
        public float V { get; set; } = 0f;

        public object HSVAssistant(HSV value)
        {
            throw new NotImplementedException();
        }
    }
}
