using System.Windows.Forms;

namespace bubuntoid.EasyDialog
{
    public static class DialogCollectionSetExtensions
    {
        /// <summary>
        /// Sets DialogCollectionSet<string> control as ListBox
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static DialogCollectionSetOptionsWithSpecifiedControlBuilder<ListBox, string> AsListBox(this DialogCollectionSetOptionsBuilder<string> builder) =>
            builder.AsControl<ListBox>()
                .ConfigureGetter((control) => (string)control.SelectedItem)
                .ConfigureSetter((control, value) => control.SelectedItem = value)
                .ConfigureOnUpdateItemsAction((control, items) =>
                {
                    control.Items.Clear();
                    foreach (var item in items)
                    {
                        control.Items.Add(item);
                    };
                });

        /// <summary>
        /// Sets DialogCollectionSet<string> control as ComboBox
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static DialogCollectionSetOptionsWithSpecifiedControlBuilder<ComboBox, string> AsComboBox(this DialogCollectionSetOptionsBuilder<string> builder) =>
            builder.AsControl<ComboBox>()
                .ConfigureGetter((control) => (string)control.SelectedItem)
                .ConfigureSetter((control, value) => control.SelectedItem = value)
                .ConfigureOnUpdateItemsAction((control, items) =>
                {
                    control.Items.Clear();
                    foreach (var item in items)
                    {
                        control.Items.Add(item);
                    };
                });
    }
}
