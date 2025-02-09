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
 1. Validation for Control added in OnStartingEdit, SetEditValue, GetEditedValue,OnSendCharToEditor
*/
#endregion 
using System;
using System.Collections;

namespace SourceGrid.Cells.Editors
{
    public static class Factory
    {
        #region DataModel Utility

        /// <summary>
        /// Construct an EditorBase for the specified type. You can set the value returned in the Editor property.
        /// If the Type support a UITypeEditor returns a EditorUITypeEditor else if the type has a StandardValues list return a EditorComboBox else if the type support string conversion returns a EditorTextBox otherwise returns null.
        /// </summary>
        /// <param name="p_Type">Type to edit</param>
        /// <returns></returns>
        public static Cells.Editors.EditorBase Create(Type p_Type)
        {
            System.ComponentModel.TypeConverter l_TypeConverter = System.ComponentModel.TypeDescriptor.GetConverter(p_Type);
            ICollection l_StandardValues = null;
            bool l_StandardValuesExclusive = false;
            if (l_TypeConverter != null)
            {
                l_StandardValues = l_TypeConverter.GetStandardValues();
                if (l_StandardValues != null && l_StandardValues.Count > 0)
                    l_StandardValuesExclusive = l_TypeConverter.GetStandardValuesExclusive();
                else
                    l_StandardValuesExclusive = false;
            }
            object l_objUITypeEditor = System.ComponentModel.TypeDescriptor.GetEditor(p_Type, typeof(System.Drawing.Design.UITypeEditor));
            if (l_objUITypeEditor != null) //UITypeEditor founded
            {
                return new Cells.Editors.TextBoxUITypeEditor(p_Type);
            }
            else
            {
                if (l_StandardValues != null) //combo box
                {
                    return new Cells.Editors.ComboBox(p_Type, l_StandardValues, l_StandardValuesExclusive);
                }
                else if (l_TypeConverter != null && l_TypeConverter.CanConvertFrom(typeof(string)))//txtbox
                {
                    return new Cells.Editors.TextBox(p_Type);
                }
                else //no editor found
                    return null;
            }
        }

        /// <summary>
        /// Construct a CellEditor for the specified type
        /// </summary>
        /// <param name="p_Type">Cell Type</param>
        /// <param name="p_DefaultValue">Default value of the editor</param>
        /// <param name="p_bAllowNull">Allow null</param>
        /// <param name="p_StandardValues">List of available values or null if there is no available values list</param>
        /// <param name="p_bStandardValueExclusive">Indicates if the p_StandardValue are the unique values supported</param>
        /// <param name="p_TypeConverter">Type converter used for conversion for the specified type</param>
        /// <param name="p_UITypeEditor">UITypeEditor if null must be populated the TypeConverter</param>
        /// <returns></returns>
        public static Cells.Editors.EditorBase Create(Type p_Type,
            object p_DefaultValue,
            bool p_bAllowNull,
            System.Collections.ICollection p_StandardValues,
            bool p_bStandardValueExclusive,
            System.ComponentModel.TypeConverter p_TypeConverter,
            System.Drawing.Design.UITypeEditor p_UITypeEditor)
        {
            Cells.Editors.EditorBase l_Editor;
            if (p_UITypeEditor == null)
            {
                if (p_StandardValues != null)
                {
                    Cells.Editors.ComboBox editCombo = new Cells.Editors.ComboBox(p_Type);
                    l_Editor = editCombo;
                }
                else if (p_TypeConverter != null && p_TypeConverter.CanConvertFrom(typeof(string)))//txtbox
                {
                    Cells.Editors.TextBox l_EditTextBox = new Cells.Editors.TextBox(p_Type);
                    l_Editor = l_EditTextBox;
                }
                else //if no editor no edit support
                {
                    l_Editor = null;
                }
            }
            else //UITypeEditor supported
            {
                Cells.Editors.TextBoxUITypeEditor txtBoxUITypeEditor = new Cells.Editors.TextBoxUITypeEditor(p_Type);

                //sandhra.prakash@siemens.com: Check if Control exists
                if (txtBoxUITypeEditor.Control != null) 
                    txtBoxUITypeEditor.Control.UITypeEditor = p_UITypeEditor;
                l_Editor = txtBoxUITypeEditor;
            }

            if (l_Editor != null)
            {
                l_Editor.DefaultValue = p_DefaultValue;
                l_Editor.AllowNull = p_bAllowNull;
                //l_Editor.CellType = p_Type;
                l_Editor.StandardValues = p_StandardValues;
                l_Editor.StandardValuesExclusive = p_bStandardValueExclusive;
                l_Editor.TypeConverter = p_TypeConverter;
            }

            return l_Editor;
        }
        #endregion
    }
}
