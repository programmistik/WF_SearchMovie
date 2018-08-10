using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieDB
{
    class MyLabel : Label
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            Point drawPoint = new Point(e.ClipRectangle.X, e.ClipRectangle.Y);
            Point startPoint = new Point(0,0);
            var maxX = e.ClipRectangle.Width;
            var maxY = e.ClipRectangle.Height;
            Size wordSize;
            
            string[] ary = Text.Split(new char[] { 'Ё' });
            if (ary.Length >= 2)
            {
                Font normalFont = Font;
                Font boldFont = new Font(normalFont, FontStyle.Bold);

                for (int i = 0; i < ary.Length; i = i + 2)
                {
                    var curX = 0;
                    Size boldSize = TextRenderer.MeasureText(ary[i], boldFont);
                    Size normalSize = TextRenderer.MeasureText(ary[i+1], normalFont);

                    Rectangle boldRect = new Rectangle(drawPoint, boldSize);
                    TextRenderer.DrawText(e.Graphics, ary[i], boldFont, boldRect, ForeColor);

                    curX += boldSize.Width;

                    startPoint.X = boldRect.Right;
                    startPoint.Y = boldRect.Top;

                    if (curX + normalSize.Width <= maxX)
                    {
                        Rectangle normalRect = new Rectangle(boldRect.Right, boldRect.Top, normalSize.Width, normalSize.Height);
                        TextRenderer.DrawText(e.Graphics, ary[i + 1], normalFont, normalRect, ForeColor);

                        drawPoint.Y = normalRect.Bottom + 10;
                    }
                    else
                    {
                        string str2Print = "";
                        int y = 0;
                        string[] words = ary[i + 1].Split(new char[] { ' ' });

                        foreach (var item in words)
                        {
                            if (item.Trim().Length > 0)
                            {
                                wordSize = e.Graphics.MeasureString(item + " ", normalFont).ToSize();
                                if (curX + wordSize.Width <= maxX)
                                {
                                    curX += wordSize.Width;
                                    str2Print += item + " ";
                                }
                                else
                                {
                                    Rectangle normalRectangle = new Rectangle(startPoint.X, startPoint.Y,
                                        curX, normalSize.Height);
                                    TextRenderer.DrawText(e.Graphics, str2Print, normalFont, normalRectangle, ForeColor);
                                    curX = wordSize.Width;
                                    startPoint.X = 0;
                                    startPoint.Y = normalRectangle.Bottom;
                                    str2Print = item + " ";
                                    y = normalRectangle.Bottom;
                                }
                            }
                        }
                        Rectangle normalR = new Rectangle(startPoint.X, startPoint.Y,
                                        curX, normalSize.Height);
                        TextRenderer.DrawText(e.Graphics, str2Print, normalFont, normalR, ForeColor);
                        y = normalR.Bottom;

                        drawPoint.Y = y + 10;
                    }
                }
            }
            else
            {
                TextRenderer.DrawText(e.Graphics, Text, Font, drawPoint, ForeColor);
            }
        }
    }
}
