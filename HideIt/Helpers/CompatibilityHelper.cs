namespace HideIt.Helpers
{
    public static class CompatibilityHelper
    {
        public static readonly string[] PROPS_AND_TREES_MANIPULATING_MODS = { "propitup", "bob", "roadsignreplacer", "trafficlightreplacer", "railwaymod", "metroreplacer", "catenaryreplacer" };

        public static readonly string[] SPRITE_DECORATIONS_MANIPULATING_MODS = { "thememixer" };

        public static bool IsAnyPropsAndTreesManipulatingModsEnabled()
        {
            if (ModUtils.IsAnyModsEnabled(PROPS_AND_TREES_MANIPULATING_MODS))
            {
                return true;
            }

            return false;
        }

        public static bool IsAnySpriteDecorationsManipulatingModsEnabled()
        {
            if (ModUtils.IsAnyModsEnabled(SPRITE_DECORATIONS_MANIPULATING_MODS))
            {
                return true;
            }

            return false;
        }
    }
}
