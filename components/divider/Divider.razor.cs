﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Components;

namespace AntDesign
{
    /**
    <summary>
        <para>A divider line separates different content.</para>

        <h2>When To Use</h2>

        <list type="bullet">
            <item>Divide sections of article.</item>
            <item>Divide inline text and links such as the operation column of table.</item>
        </list>
    </summary>
    */
    [Documentation(DocumentationCategory.Components, DocumentationType.Layout, "https://gw.alipayobjects.com/zos/alicdn/5swjECahe/Divider.svg", Title = "Divider", SubTitle = "分割线")]
    public partial class Divider : AntDomComponentBase
    {
        /// <summary>
        /// Content to show inside the divider
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// Text to show inside the divider
        /// </summary>
        [Parameter]
        public string Text { get; set; }

        /// <summary>
        /// When false, the text will not be a header style. When true it will be header style.
        /// </summary>
        /// <default value="false" />
        [Parameter]
        public bool Plain { get; set; } = false;

        /// <summary>
        /// Type of divider - `DividerType.Horizontal` | `DividerType.Vertical`
        /// </summary>
        /// <default value="DividerType.Horizontal" />
        [Parameter]
        public DividerType Type { get; set; } = DividerType.Horizontal;

        /// <summary>
        /// Content/Text orientation - `DividerOrientation.Left` | `DividerOrientation.Right` | `DividerOrientation.Center`. Ignored when not using `Text` or `ChildContent`
        /// </summary>
        /// <default value="DividerOrientation.Center" />
        [Parameter]
        public DividerOrientation Orientation { get; set; } = DividerOrientation.Center;

        /// <summary>
        /// Whether to style the line as dashed or not.
        /// </summary>
        /// <default value="false" />
        [Parameter]
        public bool Dashed { get; set; } = false;

        private void SetClass()
        {
            ClassMapper.Clear()
                .Add("ant-divider")
                .If("ant-divider", () => RTL)
                .Get(() => $"ant-divider-{Type.ToString().ToLowerInvariant()}")
                .If("ant-divider-with-text", () => Text != null || ChildContent != null)
                .GetIf(() => $"ant-divider-with-text-{Orientation.ToString().ToLowerInvariant()}", () => Text != null || ChildContent != null)
                .If($"ant-divider-plain", () => Plain && (Text != null || ChildContent != null))
                .If("ant-divider-dashed", () => Dashed)
                ;
        }

        protected override void OnInitialized()
        {
            SetClass();

            base.OnInitialized();
        }
    }
}
