﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Linq.Expressions;
using AntDesign.TableModels;
using Microsoft.AspNetCore.Components;

namespace AntDesign
{
    public class PropertyColumn<TItem, TProp> : Column<TProp>
    {
        /// <summary>
        /// Defines the value to be displayed in this column's cells.
        /// </summary>
        [Parameter]
        public Expression<Func<TItem, TProp>> Property { get; set; } = default!;

        protected override void OnInitialized()
        {
            if (Property != null)
            {
                if (IsHeader)
                {
                    GetFieldExpression = Property;
                }
                else if (IsBody)
                {
                    var compliedProperty = Property.Compile();
                    GetValue = rowData =>
                    {
                        var data = ((RowData<TItem>)rowData).DataItem.Data;
                        if (data != null)
                        {
                            return compliedProperty.Invoke(data);
                        }
                        return default;
                    };
                }
                base.OnInitialized();
            }
        }
    }
}
