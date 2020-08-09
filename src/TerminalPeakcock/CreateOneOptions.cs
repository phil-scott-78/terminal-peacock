using CommandLine;
using JetBrains.Annotations;

namespace TerminalPeakcock
{
    [UsedImplicitly]
    [Verb("one",HelpText = "Create collection of backgrounds for one color")]
    class CreateOneOptions
    {
        [Value(0, MetaName = "Name", HelpText = "Name of your set of backgrounds")]
        public string Name { get; set; }

        [Value(1, MetaName = "Color", HelpText = "Color of the generated line in hex (e.g. #123abc)")]
        public ColorFromHex Color { get; set; }

        [Option('w', "width",
            Default = 16, 
            HelpText = "Width of line to generate")]
        public int Width { get; set; }
        
        [Option("imageWidth",
            Default = 2600, 
            HelpText = "Width of image to generate. Should be larger than the max size of your console.")]
        public int ImageWidth { get; set; }
        
        [Option("imageHeight",
            Default = 2600, 
            HelpText = "Width of image to generate. Should be larger than the max size of your console.")]
        public int ImageHeight { get; set; }
        
        [Option('o', "output", HelpText = "Output location.", Default = ".\\output")]
        public string OutputLocation { get; set; }
    }
}