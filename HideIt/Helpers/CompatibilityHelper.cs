namespace HideIt.Helpers
{
    public static class CompatibilityHelper
    {
        public static readonly string[] PROP_AND_TREE_MANIPULATING_MODS = { "propitup", "bob", "roadsignreplacer", "trafficlightreplacer", "railwaymod", "metroreplacer", "catenaryreplacer" };

        public static readonly string[] SPRITE_MANIPULATING_MODS = { "thememixer" };

        public static bool IsAnyPropAndTreeManipulatingModsEnabled()
        {
            if (ModUtils.IsAnyModsEnabled(PROP_AND_TREE_MANIPULATING_MODS))
            {
                return true;
            }

            return false;
        }

        public static bool IsAnySpriteManipulatingModsEnabled()
        {
            if (ModUtils.IsAnyModsEnabled(SPRITE_MANIPULATING_MODS))
            {
                return true;
            }

            return false;
        }
    }
}
