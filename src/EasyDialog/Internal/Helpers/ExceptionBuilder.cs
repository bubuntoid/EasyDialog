namespace bubuntoid.EasyDialog.Internal
{
    public static class ExceptionBuilder
    {
        public static DialogContextConfigureException GetterIsNotConfiguredException => new DialogContextConfigureException("");

        public static DialogContextConfigureException SetterIsNotConfiguredException => new DialogContextConfigureException("");

        public static DialogContextConfigureException ControlIsNotSpecifiedException => new DialogContextConfigureException("");

        public static DialogContextConfigureException UpdateItemsEventNotSpecifiedException => new DialogContextConfigureException("");
    }
}
