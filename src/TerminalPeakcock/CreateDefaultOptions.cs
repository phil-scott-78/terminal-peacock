using CommandLine;
using JetBrains.Annotations;

namespace TerminalPeakcock
{
    [UsedImplicitly]
    [Verb("default",HelpText = "Create collection of backgrounds from default color list")]
    class CreateDefaultOptions
    {
        [Option('w', "width",
            Default = new[]{8, 16, 24}, 
            HelpText = "Width of line to generate")]
        public int[] Width { get; set; }
        
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