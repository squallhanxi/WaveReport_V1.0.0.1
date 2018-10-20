using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace WaveReport
{
    class function
    {
        public static Bitmap PContray(Bitmap a)       //反色处理函数
        {
            int w = a.Width;
            int h = a.Height;
            Bitmap dstBitmap = new Bitmap(a.Width, a.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            System.Drawing.Imaging.BitmapData srcData = a.LockBits(new Rectangle(0, 0, w, h), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            System.Drawing.Imaging.BitmapData dstData = dstBitmap.LockBits(new Rectangle(0, 0, w, h), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            unsafe
            {
                byte* pIn = (byte*)srcData.Scan0.ToPointer();
                byte* pOut = (byte*)dstData.Scan0.ToPointer();
                byte* p;
                int stride = srcData.Stride;
                int r, g, b;
                for (int y = 0; y < h; y++)
                {
                    for (int x = 0; x < w; x++)
                    {
                        p = pIn;
                        r = p[2];
                        g = p[1];
                        b = p[0];
                        pOut[2] = (byte)(255 - r);
                        pOut[1] = (byte)(255 - g);
                        pOut[0] = (byte)(255 - b);
                        pIn += 3;
                        pOut += 3;
                    }
                    pIn += srcData.Stride - w * 3;
                    pOut += srcData.Stride - w * 3;
                }
                a.UnlockBits(srcData);
                dstBitmap.UnlockBits(dstData);
                return dstBitmap;
            }
        }

        public static Bitmap Cut(Bitmap b, int StartX, int StartY, int iWidth, int iHeight)     //图片裁剪函数
        {
            if (b == null)
            {
                return null;
            }
            int w = b.Width;
            int h = b.Height;
            if (StartX >= w || StartY >= h)
            {
                return null;
            }
            if (StartX + iWidth > w)
            {
                iWidth = w - StartX;
            }
            if (StartY + iHeight > h)
            {
                iHeight = h - StartY;
            }
            try
            {
                Bitmap bmpOut = new Bitmap(iWidth, iHeight, PixelFormat.Format24bppRgb);
                Graphics g = Graphics.FromImage(bmpOut);
                g.DrawImage(b, new Rectangle(0, 0, iWidth, iHeight), new Rectangle(StartX, StartY, iWidth, iHeight), GraphicsUnit.Pixel);
                g.Dispose();
                return bmpOut;
            }
            catch
            {
                return b;
            }
        }
    }
}
