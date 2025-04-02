// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace AntDesign.Core;

public interface IInputMaskConverter
{
    public string Convert(string value, string mask);
}
