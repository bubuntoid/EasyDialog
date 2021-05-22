namespace bubuntoid.EasyDialog
{
    /// <summary>
    /// Model that used for creating your own theme for MaterialStyle. 
    /// Contains existing themes in static properties
    /// </summary>
    public class MaterialColorScheme
    {
        public MaterialThemePrimaryColor Primary { get; set; }
        public MaterialThemePrimaryColor DarkPrimary { get; set; }
        public MaterialThemePrimaryColor LightPrimary { get; set; }
        public MaterialThemeAccent Accent { get; set; }
        public MaterialThemeTextShade TextShade { get; set; }

        /// <summary>
        /// Default values are: Light, BlueGrey800, BlueGrey900, BlueGrey500, LightBlue200, White
        /// </summary>
        /// <returns></returns>
        public static MaterialColorScheme Default
        {
            get
            {
                return new MaterialColorScheme()
                {
                    Primary = MaterialThemePrimaryColor.BlueGrey800,
                    DarkPrimary = MaterialThemePrimaryColor.BlueGrey900,
                    LightPrimary = MaterialThemePrimaryColor.BlueGrey500,
                    Accent = MaterialThemeAccent.LightBlue200,
                    TextShade = MaterialThemeTextShade.White,
                };
            }
        }

        public static MaterialColorScheme Green
        {
            get
            {
                return new MaterialColorScheme()
                {
                    Primary = MaterialThemePrimaryColor.Green800,
                    DarkPrimary = MaterialThemePrimaryColor.Green900,
                    LightPrimary = MaterialThemePrimaryColor.Green500,
                    Accent = MaterialThemeAccent.LightGreen200,

                    TextShade = MaterialThemeTextShade.White,
                };
            }
        }

        public static MaterialColorScheme LightGreen
        {
            get
            {
                return new MaterialColorScheme()
                {
                    Primary = MaterialThemePrimaryColor.LightGreen800,
                    DarkPrimary = MaterialThemePrimaryColor.LightGreen900,
                    LightPrimary = MaterialThemePrimaryColor.LightGreen500,
                    Accent = MaterialThemeAccent.LightGreen200,

                    TextShade = MaterialThemeTextShade.White,
                };
            }
        }

        public static MaterialColorScheme Red
        {
            get
            {
                return new MaterialColorScheme()
                {
                    Primary = MaterialThemePrimaryColor.Red800,
                    DarkPrimary = MaterialThemePrimaryColor.Red900,
                    LightPrimary = MaterialThemePrimaryColor.Red500,
                    Accent = MaterialThemeAccent.Red200,

                    TextShade = MaterialThemeTextShade.White,
                };
            }
        }

        public static MaterialColorScheme Amber
        {
            get
            {
                return new MaterialColorScheme()
                {
                    Primary = MaterialThemePrimaryColor.Amber800,
                    DarkPrimary = MaterialThemePrimaryColor.Amber900,
                    LightPrimary = MaterialThemePrimaryColor.Amber500,
                    Accent = MaterialThemeAccent.Amber200,

                    TextShade = MaterialThemeTextShade.White,
                };
            }
        }

        public static MaterialColorScheme Brown
        {
            get
            {
                return new MaterialColorScheme()
                {
                    Primary = MaterialThemePrimaryColor.Brown800,
                    DarkPrimary = MaterialThemePrimaryColor.Brown900,
                    LightPrimary = MaterialThemePrimaryColor.Brown500,
                    Accent = MaterialThemeAccent.Teal200,

                    TextShade = MaterialThemeTextShade.White,
                };
            }
        }

        public static MaterialColorScheme Teal
        {
            get
            {
                return new MaterialColorScheme()
                {
                    Primary = MaterialThemePrimaryColor.Teal800,
                    DarkPrimary = MaterialThemePrimaryColor.Teal900,
                    LightPrimary = MaterialThemePrimaryColor.Teal500,
                    Accent = MaterialThemeAccent.Teal200,

                    TextShade = MaterialThemeTextShade.White,
                };
            }
        }

        public static MaterialColorScheme Yellow
        {
            get
            {
                return new MaterialColorScheme()
                {
                    Primary = MaterialThemePrimaryColor.Yellow800,
                    DarkPrimary = MaterialThemePrimaryColor.Yellow900,
                    LightPrimary = MaterialThemePrimaryColor.Yellow500,
                    Accent = MaterialThemeAccent.Yellow200,

                    TextShade = MaterialThemeTextShade.White,
                };
            }
        }

        public static MaterialColorScheme Pink
        {
            get
            {
                return new MaterialColorScheme()
                {
                    Primary = MaterialThemePrimaryColor.Pink800,
                    DarkPrimary = MaterialThemePrimaryColor.Pink900,
                    LightPrimary = MaterialThemePrimaryColor.Pink500,
                    Accent = MaterialThemeAccent.Pink200,

                    TextShade = MaterialThemeTextShade.White,
                };
            }
        }

        public static MaterialColorScheme Purple
        {
            get
            {
                return new MaterialColorScheme()
                {
                    Primary = MaterialThemePrimaryColor.Purple800,
                    DarkPrimary = MaterialThemePrimaryColor.Purple900,
                    LightPrimary = MaterialThemePrimaryColor.Purple500,
                    Accent = MaterialThemeAccent.Purple200,

                    TextShade = MaterialThemeTextShade.White,
                };
            }
        }

        public static MaterialColorScheme DeepPurple
        {
            get
            {
                return new MaterialColorScheme()
                {
                    Primary = MaterialThemePrimaryColor.DeepPurple800,
                    DarkPrimary = MaterialThemePrimaryColor.DeepPurple900,
                    LightPrimary = MaterialThemePrimaryColor.DeepPurple500,
                    Accent = MaterialThemeAccent.DeepPurple200,

                    TextShade = MaterialThemeTextShade.White,
                };
            }
        }

        public static MaterialColorScheme Orange
        {
            get
            {
                return new MaterialColorScheme()
                {
                    Primary = MaterialThemePrimaryColor.Orange800,
                    DarkPrimary = MaterialThemePrimaryColor.Orange900,
                    LightPrimary = MaterialThemePrimaryColor.Orange500,
                    Accent = MaterialThemeAccent.Orange200,

                    TextShade = MaterialThemeTextShade.White,
                };
            }
        }

        public static MaterialColorScheme DeepOrange
        {
            get
            {
                return new MaterialColorScheme()
                {
                    Primary = MaterialThemePrimaryColor.DeepOrange800,
                    DarkPrimary = MaterialThemePrimaryColor.DeepOrange900,
                    LightPrimary = MaterialThemePrimaryColor.DeepOrange500,
                    Accent = MaterialThemeAccent.DeepOrange200,

                    TextShade = MaterialThemeTextShade.White,
                };
            }
        }

        public static MaterialColorScheme Lime
        {
            get
            {
                return new MaterialColorScheme()
                {
                    Primary = MaterialThemePrimaryColor.Lime800,
                    DarkPrimary = MaterialThemePrimaryColor.Lime900,
                    LightPrimary = MaterialThemePrimaryColor.Lime500,
                    Accent = MaterialThemeAccent.Lime200,

                    TextShade = MaterialThemeTextShade.White,
                };
            }
        }

        public static MaterialColorScheme LightBlue
        {
            get
            {
                return new MaterialColorScheme()
                {
                    Primary = MaterialThemePrimaryColor.LightBlue800,
                    DarkPrimary = MaterialThemePrimaryColor.LightBlue900,
                    LightPrimary = MaterialThemePrimaryColor.LightBlue500,
                    Accent = MaterialThemeAccent.LightBlue200,

                    TextShade = MaterialThemeTextShade.White,
                };
            }
        }

        public static MaterialColorScheme Indigo
        {
            get
            {
                return new MaterialColorScheme()
                {
                    Primary = MaterialThemePrimaryColor.Indigo800,
                    DarkPrimary = MaterialThemePrimaryColor.Indigo900,
                    LightPrimary = MaterialThemePrimaryColor.Indigo500,
                    Accent = MaterialThemeAccent.Indigo200,

                    TextShade = MaterialThemeTextShade.White,
                };
            }
        }

        public static MaterialColorScheme Grey
        {
            get
            {
                return new MaterialColorScheme()
                {
                    Primary = MaterialThemePrimaryColor.Grey800,
                    DarkPrimary = MaterialThemePrimaryColor.Grey900,
                    LightPrimary = MaterialThemePrimaryColor.Grey500,
                    Accent = MaterialThemeAccent.Teal200,

                    TextShade = MaterialThemeTextShade.White,
                };
            }
        }

        public static MaterialColorScheme Cyan
        {
            get
            {
                return new MaterialColorScheme()
                {
                    Primary = MaterialThemePrimaryColor.Cyan800,
                    DarkPrimary = MaterialThemePrimaryColor.Cyan900,
                    LightPrimary = MaterialThemePrimaryColor.Cyan500,
                    Accent = MaterialThemeAccent.Cyan200,

                    TextShade = MaterialThemeTextShade.White,
                };
            }
        }
    }
}