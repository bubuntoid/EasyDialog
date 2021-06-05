using bubuntoid.EasyDialog.Internal.Providers;

namespace bubuntoid.EasyDialog
{
    public static class MaterialSkinExtensions
    {
        /// <summary>
        /// Uses material style
        /// </summary>
        /// <returns></returns>
        public static DialogContextConfigureOptionsBuilder<TContext> UseMaterialStyle<TContext>(
            this DialogContextConfigureOptionsBuilder<TContext> builder)
        {
            return UseMaterialStyle(builder, MaterialTheme.Light);
        }

        /// <summary>
        /// Uses material style with specified theme
        /// </summary>
        /// <param name="theme"></param>
        /// <returns></returns>
        public static DialogContextConfigureOptionsBuilder<TContext> UseMaterialStyle<TContext>(
            this DialogContextConfigureOptionsBuilder<TContext> builder, 
            MaterialTheme theme)
        {
            return UseMaterialStyle(builder, theme, MaterialColorScheme.Default);
        }

        /// <summary>
        /// Uses material style with specified theme and color scheme
        /// </summary>
        /// <param name="theme"></param>
        /// <param name="scheme"></param>
        /// <returns></returns>
        public static DialogContextConfigureOptionsBuilder<TContext> UseMaterialStyle<TContext>(
            this DialogContextConfigureOptionsBuilder<TContext> builder, 
            MaterialTheme theme, 
            MaterialColorScheme scheme)
        {
            builder.UseFormProvider(new MaterialFormProvider(theme, scheme));
            return builder;
        }
    }
}
