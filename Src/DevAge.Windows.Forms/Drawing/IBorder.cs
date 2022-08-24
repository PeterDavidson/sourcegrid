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
// Copyright (C) Siemens AG 2016    
//------------------------------------------------------------------------ 
// Project           : UIGrid
// Author            : Sandhra.Prakash@siemens.com
// In Charge for Code: Sandhra.Prakash@siemens.com
//------------------------------------------------------------------------ 

/*Changes :
 * 1. Draw -  sandhra.prakash@siemens.com: draws part by part of rectangle. Signature of method changed.
                conditions are added so that only specified border is drawn. 
*/
#endregion Copyright

using System;
using System.Drawing;

namespace DevAge.Drawing
{
    /// <summary>
    /// Interface for all borders.
    /// </summary>
    public interface IBorder : ICloneable
    {
        RectangleF GetContentRectangle(RectangleF backGroundArea);

        SizeF GetExtent(SizeF contentSize);

        /// <summary>
        /// Draw the current VisualElement in the specified Graphics object.
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="area"></param>
        /// <param name="partTypeTobeDrawn">sandhra.prakash@siemens.com: specifies the part to be drawn.</param>
        void Draw(GraphicsCache graphics, System.Drawing.RectangleF area, BorderPartType partTypeTobeDrawn);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="area"></param>
        /// <param name="point"></param>
        /// <param name="distanceFromBorder">Returns the distance of the specified point from the border rectangle. -1 if is not inside the border. Returns a positive value or 0 if inside the border. Consider always the distance from the outer border.</param>
        /// <returns></returns>
        RectanglePartType GetPointPartType(System.Drawing.RectangleF area,
                                                System.Drawing.PointF point,
                                                out float distanceFromBorder);
    }
}
