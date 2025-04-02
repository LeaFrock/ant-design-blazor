// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace AntDesign
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    internal class DocumentationAttribute(DocumentationCategory category, DocumentationType type, string coverImageUrl) : Attribute
    {
        public DocumentationCategory Category { get; } = category;
        public int Columns { get; set; } = 2;
        public string CoverImageUrl { get; } = coverImageUrl;
        public bool OutputApi { get; set; } = true;
        public string? SubTitle { get; set; } = null;
        public string Title { get; set; } = null;
        public DocumentationType Type { get; } = type;
    }
}
