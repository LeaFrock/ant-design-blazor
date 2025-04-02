// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace AntDesign.Core.Services;

public class ClientDimensionService(IJSRuntime js)
{
    private double? _scrollBarSize;

    public async Task<double> GetScrollBarSizeAsync()
    {
        _scrollBarSize ??= await js.InvokeAsync<double>(JSInteropConstants.DomMainpulationHelper.GetScrollBarSize, false);

        return _scrollBarSize.Value;
    }
}
