using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline.Processors;

using xTile;
using xTile.Format;

namespace xTile.Pipeline
{
    /// <summary>
    /// Content processor class for tIDE map files
    /// </summary>
    [ContentProcessor(DisplayName = "tIDE Map Processor")]
    public class TideProcessor : ContentProcessor<Map, Map>
    {
        /// <summary>
        /// Process a tIDE map object.
        /// </summary>
        /// <param name="input">Input map object</param>
        /// <param name="contentProcessorContext">Processor context object</param>
        /// <returns></returns>
        public override Map Process(Map input, ContentProcessorContext contentProcessorContext)
        {
            return input;
        }
    }
}