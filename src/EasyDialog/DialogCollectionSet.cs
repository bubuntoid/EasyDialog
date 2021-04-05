using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

using bubuntoid.EasyDialog.Internal;
using bubuntoid.EasyDialog.Internal.Models;

namespace bubuntoid.EasyDialog
{
    public class DialogCollectionSet<TValue> : IDialogCollectionSet
    {
        #region Implementations
        IEnumerable<object> IDialogCollectionSet.DataSource
        {
            get => DataSource.Cast<object>().ToList();
            set => DataSource = value.Cast<TValue>();
        }

        Action<Control, IEnumerable<object>> IDialogCollectionSet.UpdateItemsEvent { get; set; }
        bool IDialogCollectionSet.UpdateItemsEventSpecifiedFromBuilder { get; set; }

        string IDialogSet.PropertyName { get; set; }
        Control IDialogSet.Control { get; set; }
        
        bool IDialogSet.ControlSpecifiedFromBuilder { get; set; }
        bool IDialogSet.GetterSpecifiedFromBuilder { get; set; }
        bool IDialogSet.SetterSpecifiedFromBuilder { get; set; }

        Func<Control, object> IDialogSet.Getter { get; set; }
        Action<Control, object> IDialogSet.Setter{ get; set; }

        bool IDialogSet.Ignore { get; set; } = false;
        bool IDialogSet.Enabled { get; set; } = true;
        bool IDialogSet.FullRow { get; set; } = false;
        string IDialogSet.Name { get; set; }
        int? IDialogSet.ControlHeight { get; set; }
        object IDialogSet.PreValue { get; set; }
        #endregion

        public TValue Value
        {
            get
            {
                if (Base.Getter == null)
                    throw ExceptionBuilder.GetterIsNotConfiguredException(Base);

                return (TValue)Base.Getter(Base.Control);
            }
            set
            {
                if (Base.Setter == null)
                    throw ExceptionBuilder.SetterIsNotConfiguredException(Base);

                Base.Setter(Base.Control, value);
            }
        }
        public Control Control => Base.Control;

        private IEnumerable<TValue> _dataSource = new HashSet<TValue>();
        public IEnumerable<TValue> DataSource
        {
            get
            {
                Base.UpdateItemsEvent?.Invoke(Base.Control, _dataSource.Cast<object>());
                return _dataSource;
            }

            set
            {
                _dataSource = value;
                Base.UpdateItemsEvent?.Invoke(Base.Control, _dataSource.Cast<object>());
            }
        }

        private IDialogCollectionSet Base => this;

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
}
