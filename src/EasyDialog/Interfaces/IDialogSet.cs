using System;
using System.Collections.Generic;

using bubuntoid.EasyDialog.Internal.Models;

namespace bubuntoid.EasyDialog;

public interface IDialogSet
{
    public string Name { get; set; }
    
    internal InternalDialogSetData Data { get; }
    internal Dictionary<Type, SupportedTypeSetup> SupportedTypesSetups { get; }
}