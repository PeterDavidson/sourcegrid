#region Copyright

/*SourceGrid LICENSE (MIT style)

Copyright (c) 2005 - 2012 http://sourcegrid.codeplex.com/, Davide Icardi, Darius Damalakas

Permission is hereby granted, free of charge, to any person obtaining 
a copy of this software and associated documentation files (the "Software"), 
to deal in the Software without restriction, including without limitation 
the rights to use, copy, modify, merge, publish, distribute, sublicense, 
and/or sell copies of the Software, and to permit persons to whom the 
Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included 
in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, 
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES 
OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, 
DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, 
ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
DEALINGS IN THE SOFTWARE. */

//------------------------------------------------------------------------ 
// Copyright (C) Siemens AG 2017    
//------------------------------------------------------------------------ 
// Project           : UIGrid
// Author            : Sandhra.Prakash@siemens.com
// In Charge for Code: Sandhra.Prakash@siemens.com
//------------------------------------------------------------------------ 

/*Changes :
 * 1. OnDrawBorder : Draw method signature is changed. as the IBorder Draw method was changed to add the 
                part of border which needs to be drawn. Change needs to be reflected here as well
*/
#endregion Copyright

using System;
using System.Drawing;

namespace DevAge.Drawing.VisualElements
{
    [Serializable]
    public class Header : HeaderBase
    {
        #region Constuctor
        /// <summary>
        /// Default constructor
        /// </summary>
        public Header()
            : this(45)
        {
        }

        public Header(float gradientAngle)
        {
            GradientAngle = gradientAngle;

            mBackground = new BackgroundLinearGradient(Color.Empty, Color.Empty, GradientAngle);

            BackColor = Color.FromKnownColor(KnownColor.Control);

            Color darkdarkControl = Utilities.CalculateLightDarkColor(BackColor, -0.2f);
            BorderLine darkB = new BorderLine(darkdarkControl, 1);
            mBorder = new RectangleBorder(darkB, darkB);
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="other"></param>
        public Header(Header other)
            : base(other)
        {
            BackColor = other.BackColor;
            Border = other.Border;
            GradientAngle = other.GradientAngle;
        }
        #endregion

        #region Properties
        private Color mBackColor;
        /// <summary>
        /// Back Color
        /// </summary>
        public Color BackColor
        {
            get { return mBackColor; }
            set { mBackColor = value; }
        }

        private RectangleBorder mBorder;
        /// <summary>
        /// Border
        /// </summary>
        public RectangleBorder Border
        {
            get { return mBorder; }
            set { mBorder = value; }
        }

        private float mGradientAngle = 45;
        /// <summary>
        /// Gradient angle used for linear gradient.
        /// </summary>
        public float GradientAngle
        {
            get { return mGradientAngle; }
            set { mGradientAngle = value; }
        }

        private BackgroundColorStyle mBackgroundColorStyle = BackgroundColorStyle.Linear;
        /// <summary>
        /// Draw mode for the header. Default is Linear.
        /// </summary>
        public BackgroundColorStyle BackgroundColorStyle
        {
            get { return mBackgroundColorStyle; }
            set { mBackgroundColorStyle = value; }
        }

        private BackgroundLinearGradient mBackground;

        #endregion

        /// <summary>
        /// Clone
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            return new Header(this);
        }

        /// <summary>
        /// Calculate the client area where the content can be drawed, usually removing the area used by the background, for example removing a border.
        /// </summary>
        /// <returns></returns>
        public override RectangleF GetBackgroundContentRectangle(MeasureHelper measure, RectangleF backGroundArea)
        {
            backGroundArea = mBorder.GetContentRectangle(backGroundArea);

            return base.GetBackgroundContentRectangle(measure, backGroundArea);
        }

        /// <summary>
        /// Calculate the total area used by the backgound and the content, adding the background area to the content area.
        /// </summary>
        /// <returns></returns>
        public override SizeF GetBackgroundExtent(MeasureHelper measure, SizeF contentSize)
        {
            SizeF extend = base.GetBackgroundExtent(measure, contentSize);

            extend = mBorder.GetExtent(contentSize);

            return extend;
        }

        protected override void OnDraw(GraphicsCache graphics, RectangleF area)
        {
            //The background is drawed on the background (back)
            OnDrawBackground(graphics, area);

            //The border is drawed on the background
            OnDrawBorder(graphics, area);
        }

        protected virtual void OnDrawBorder(GraphicsCache graphics, RectangleF area)
        {
            //sandhra.prakash@siemens.com: as the IBorder Draw method was changed to add the 
            //part of border which needs to be drawn. Change needs to be reflected here as well
            mBorder.Draw(graphics, area, BorderPartType.All);
        }

        protected virtual void OnDrawBackground(GraphicsCache graphics, RectangleF area)
        {
            Color darkdarkControl = Utilities.CalculateLightDarkColor(BackColor, -0.2f);
            //Color darkControl = Utilities.CalculateLightDarkColor(BackColor, -0.1f);
            Color lightControl = Utilities.CalculateLightDarkColor(BackColor, 0.5f);
            Color hotLightControl = Utilities.CalculateMiddleColor(Color.FromKnownColor(KnownColor.Highlight), lightControl);

            if (Style == ControlDrawStyle.Hot)
            {
                mBackground.FirstColor = hotLightControl;
                mBackground.SecondColor = hotLightControl;
            }
            else if (Style == ControlDrawStyle.Pressed)
            {
                mBackground.FirstColor = darkdarkControl;
                mBackground.SecondColor = lightControl;
            }
            else //Normal or Disabled
            {
                if (BackgroundColorStyle == BackgroundColorStyle.Linear)
                {
                    mBackground.FirstColor = lightControl;
                    mBackground.SecondColor = darkdarkControl;
                }
                else if (BackgroundColorStyle == BackgroundColorStyle.Solid)
                {
                    mBackground.FirstColor = BackColor;
                    mBackground.SecondColor = BackColor;
                }
                else
                {
                    mBackground.FirstColor = Color.Empty;
                    mBackground.SecondColor = Color.Empty;
                }
            }

            mBackground.Angle = GradientAngle;

            mBackground.Draw(graphics, area);
        }

    }
}
