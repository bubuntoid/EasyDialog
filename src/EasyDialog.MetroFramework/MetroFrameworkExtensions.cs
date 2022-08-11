using bubuntoid.EasyDialog.Internal.Providers;

namespace bubuntoid.EasyDialog;

public static class MetroFrameworkExtensions
{
    /// <summary>
    /// Uses metro UI style
    /// </summary>
    /// <returns></returns>
    public static DialogContextConfigureOptionsBuilder<TContext> UseMetroStyle<TContext>(this DialogContextConfigureOptionsBuilder<TContext> builder)
    {
        return UseMetroStyle(builder, MetroTheme.Default);
    }

    /// <summary>
    /// Uses metro UI style with specified theme
    /// </summary>
    /// <param name="theme"></param>
    /// <returns></returns>
    public static DialogContextConfigureOptionsBuilder<TContext> UseMetroStyle<TContext>(this DialogContextConfigureOptionsBuilder<TContext> builder, MetroTheme theme)
    {
        builder.UseFormProvider(new MetroFormProvider(theme));
        return builder;
    }
}