using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

using bubuntoid.EasyDialog.Internal;
using bubuntoid.EasyDialog.Internal.Models;

namespace bubuntoid.EasyDialog;

/// <summary>
/// Docs: https://github.com/bubuntoid/EasyDialog
/// </summary>
/// <typeparam name="TValue"></typeparam>
public class DialogCollectionSet<TValue> : IDialogCollectionSet
{
    /// <summary>
    /// Presents value of this DialogCollectionSet<TValue>
    /// </summary>
    public TValue Value
    {
        get
        {
            if (Base.Data.Getter == null)
                throw ExceptionBuilder.GetterIsNotConfiguredException(Base);

            return (TValue)Base.Data.Getter(Base.Data.Control);
        }
        set
        {
            if (Base.Data.Setter == null)
                throw ExceptionBuilder.SetterIsNotConfiguredException(Base);

            Base.Data.Setter(Base.Data.Control, value);
        }
    }

    /// <summary>
    /// Presents current control of this DialogCollectionSet<TValue>
    /// </summary>
    public Control Control => Base.Data.Control;

    private IEnumerable<TValue> _dataSource = new HashSet<TValue>();

    /// <summary>
    /// Presents data source of this DialogCollectionSet<TValue>
    /// </summary>
    public IEnumerable<TValue> DataSource
    {
        get
        {
            Base.OnUpdateItemsAction?.Invoke(Base.Data.Control, _dataSource.Cast<object>());
            return _dataSource;
        }

        set
        {
            _dataSource = value;
            Base.OnUpdateItemsAction?.Invoke(Base.Data.Control, _dataSource.Cast<object>());
        }
    }

    private IDialogCollectionSet Base => this;

    IEnumerable<object> IDialogCollectionSet.DataSource
    {
        get => DataSource.Cast<object>().ToList();
        set => DataSource = value.Cast<TValue>();
    }

    Action<Control, IEnumerable<object>> IDialogCollectionSet.OnUpdateItemsAction { get; set; }
    bool IDialogCollectionSet.OnUpdateItemsActionSpecifiedFromBuilder { get; set; }

    InternalDialogSetData IDialogSet.Data { get; } = new InternalDialogSetData();
    Dictionary<Type, SupportedTypeSetup> IDialogSet.SupportedTypesSetups => new()
    {
        [typeof(string)] = new SupportedTypeSetup(control: () => new ComboBox(),
            getter: (control) => (control as ComboBox).SelectedItem,
            setter: (control, value) => (control as ComboBox).SelectedItem = value,
            updateItemsEvent: (control, items) =>
            {
                var comboBox = (ComboBox)control;
                comboBox.Items.Clear();

                if (_dataSource != null)
                {
                    foreach (var item in items)
                    {
                        comboBox.Items.Add(item);
                    };
                }
            })
    };
}