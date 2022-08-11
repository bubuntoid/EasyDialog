using System;
using System.Collections.Generic;

using bubuntoid.EasyDialog.Internal.Models;

namespace bubuntoid.EasyDialog;

public interface IDialogSet
{
    internal InternalDialogSetData Data { get; }
    internal Dictionary<Type, SupportedTypeSetup> SupportedTypesSetups { get; }
}