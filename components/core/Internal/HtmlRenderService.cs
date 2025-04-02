// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace AntDesign
{
    public class HtmlRenderService(HtmlRenderer htmlRenderer)
    {
        public async ValueTask<string> RenderAsync(RenderFragment renderFragment)
        {
            var text = await htmlRenderer.Dispatcher.InvokeAsync(() => htmlRenderer.RenderComponentAsync(new EmptyComponent(renderFragment), ParameterView.Empty));
            return string.Join("", text.Tokens);
        }

        private class EmptyComponent(RenderFragment content) : IComponent
        {
            private RenderHandle _renderHandle;

            public void Attach(RenderHandle renderHandle)
            {
                _renderHandle = renderHandle;
            }

            public Task SetParametersAsync(ParameterView parameters)
            {
                _renderHandle.Render(content);
                return Task.CompletedTask;
            }
        }
    }
}
