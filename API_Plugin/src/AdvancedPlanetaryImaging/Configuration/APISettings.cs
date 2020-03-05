using Kopernicus.ConfigParser.Attributes;
using Kopernicus.ConfigParser.Enumerations;
using Kopernicus.ConfigParser.BuiltinTypeParsers;
using System;
using System.Collections.Generic;

namespace AdvancedPlanetaryImaging
{
    [RequireConfigType(ConfigType.Node)]
    public class APISettings
    {
        private Boolean debug = false;

        [ParserTarget("debugMode")]
        public NumericParser<Boolean> Debug = new NumericParser<bool>(false);

        
        [ParserTargetCollection("Overlays", AllowMerge = true)]
        List<String> Overlays { get; set; }
    }
}
