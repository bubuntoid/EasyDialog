namespace bubuntoid.EasyDialog.Internal
{
    internal static class ExceptionBuilder
    {
        public static DialogContextConfigureException GetterIsNotConfiguredException(IDialogSet set) =>
            new DialogContextConfigureException($"Getter of item '{set.Data.PropertyName}' is not configured. Configure it by calling .ConfigureGetter(...)\n" +
                $"You can find usage and samples here: https://github.com/bubuntoid/EasyDialog");

        public static DialogContextConfigureException SetterIsNotConfiguredException(IDialogSet set) =>
             new DialogContextConfigureException($"Setter of item '{set.Data.PropertyName}' is not configured. Configure it by calling .ConfigureSetter(...)\n" +
                $"You can find usage and samples here: https://github.com/bubuntoid/EasyDialog");

        public static DialogContextConfigureException ControlIsNotSpecifiedException(IDialogSet set) =>
               new DialogContextConfigureException($"Control of item '{set.Data.PropertyName}' is not recognized by default or not configured. Configure it by calling .AsControl<YourControl>()\n" +
                $"You can find usage and samples here: https://github.com/bubuntoid/EasyDialog");

        public static DialogContextConfigureException UpdateItemsEventNotSpecifiedException(IDialogSet set) =>
        new DialogContextConfigureException($"UpdateItemsEvent of item '{set.Data.PropertyName}' is not not configured. Configure it by calling .ConfigureUpdateItemsEvent(...)\n" +
                $"You can find usage and samples here: https://github.com/bubuntoid/EasyDialog");
    }
}
