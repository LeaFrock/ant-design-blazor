﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;

namespace AntDesign.Docs
{
    public class DemoComponent
    {
        public string Category { get; set; }
        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string Type { get; set; }

        public string Desc { get; set; }

        public string ApiDoc { get; set; }

        public string Faq { get; set; }

        public int? Cols { get; set; }

        public string Cover { get; set; }

        public List<DemoItem> DemoList { get; set; }
    }

    public class DemoItem
    {
        public decimal Order { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Code { get; set; }

        public string Type { get; set; }

        public string Style { get; set; }

        public int? Iframe { get; set; }

        public string Link { get; set; }

        public bool? Docs { get; set; }

        public bool Debug { get; set; }
    }
}
