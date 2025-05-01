public enum Language
{
    English,
    Spanish
}

public static class Strings
{
    // UI Texts
    public static string BtnOpen;
    public static string BtnMake;
    public static string GroupAppSettings;
    public static string ComboColor;
    public static string ComboColorRescaled;
    public static string ComboMonochromatic;
    public static string ComboBW;
    public static string BtnSetLogo;
    public static string GroupLatestRecipes;
    public static string MenuFile;
    public static string MenuHelp;
    public static string MenuFileNew;
    public static string MenuFileOpen;
    public static string MenuHelpAbout;
    public static string LabelAbout;
    public static string LabelRecipeName;
    public static string LabelIngredients;
    public static string LabelSteps;
    public static string BtnSave;
    public static string BtnClose;
    public static string BtnBack;
    public static string BtnNoLastRecipe;
    public static string BtnNoRecipe;
    public static string MsgNoRecipeSelected;
    public static string MsgResetSettings;
    public static string MsgRestartToApply;
    public static string ToolTipReset;
    public static string ToolTipRestart;
    public static string MenuLanguage;
    public static string MenuLanguageChange;

    public static void SetLang(Language lang)
    {
        switch (lang)
        {
            case Language.English:
                BtnOpen = "Open";
                BtnMake = "Make";
                GroupAppSettings = "App settings";
                ComboColor = "Color";
                ComboColorRescaled = "Color (rescaled)";
                ComboMonochromatic = "Monochromatic";
                ComboBW = "B&W";
                BtnSetLogo = "Set logo";
                GroupLatestRecipes = "Latest recipes";
                MenuFile = "&File";
                MenuHelp = "&Help";
                MenuFileNew = "&New";
                MenuFileOpen = "&Open";
                MenuHelpAbout = "&About Recip";
                LabelAbout = "Recip 1.0 is the latest build (as of 29-04-2025). Its license is Creative\nCommons - Attribution - Non Commercial - Share Alike. To contribute,\nvisit the project site: https://github.com/rayelprooficial/recip";
                LabelRecipeName = "Recipe Name:";
                LabelIngredients = "Ingredients:";
                LabelSteps = "Steps:";
                BtnSave = "Save";
                BtnClose = "Close";
                BtnBack = "< Back";
                BtnNoLastRecipe = "No last recipe";
                BtnNoRecipe = "No recipe";
                MsgNoRecipeSelected = "No Recipe Selected";
                MsgResetSettings = "Are you sure you want to reset the settings?";
                MsgRestartToApply = "Restart app to apply changes?";
                ToolTipReset = "Reset settings to default";
                ToolTipRestart = "Restart app";
                MenuLanguage = "&Language";
                MenuLanguageChange = "&Change Language";
                break;

            case Language.Spanish:
                BtnOpen = "Abrir";
                BtnMake = "Crear";
                GroupAppSettings = "Ajustes de la app";
                ComboColor = "Color";
                ComboColorRescaled = "Color (reescalado)";
                ComboMonochromatic = "Monocromático";
                ComboBW = "B/N";
                BtnSetLogo = "Cambiar logo";
                GroupLatestRecipes = "Recetas recientes";
                MenuFile = "Ar&chivo";
                MenuHelp = "A&yuda";
                MenuFileNew = "&Nuevo";
                MenuFileOpen = "&Abrir";
                MenuHelpAbout = "Acerca de &Recip";
                LabelAbout = "Recip 1.0 es la versión más reciente (al 29-04-2025). Su licencia es Creative\nCommons - Atribución - No Comercial - Compartir Igual. Para contribuir,\nvisita el proyecto: https://github.com/rayelprooficial/recip";
                LabelRecipeName = "Nombre de la receta:";
                LabelIngredients = "Ingredientes:";
                LabelSteps = "Pasos:";
                BtnSave = "Guardar";
                BtnClose = "Cerrar";
                BtnBack = "< Atrás";
                BtnNoLastRecipe = "Sin última receta";
                BtnNoRecipe = "Sin receta";
                MsgNoRecipeSelected = "No se ha seleccionado ninguna receta";
                MsgResetSettings = "¿Estás seguro de que quieres restablecer la configuración?";
                MsgRestartToApply = "¿Reiniciar app para aplicar cambios?";
                ToolTipReset = "Restablecer configuración a predeterminada";
                ToolTipRestart = "Reiniciar app";
                MenuLanguage = "&Idioma";
                MenuLanguageChange = "Ca&mbiar idioma";
                break;
        }
    }
}
