using System.IO;
using System.Threading.Tasks;
using CommandLine;
using JetBrains.Annotations;
using ShellProgressBar;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace TerminalPeakcock
{
    [UsedImplicitly]
    public class Program
    {
        static async Task Main(string[] args)
        {
            await Parser.Default.ParseArguments<CreateOneOptions, CreateDefaultOptions>(args)
                .MapResult(
                    (CreateOneOptions opts) => CreateOne(opts),
                    (CreateDefaultOptions opts) => CreateDefaults(opts),
                    errs => Task.FromResult(0));
        }

        private static async Task<int> CreateDefaults(CreateDefaultOptions opts)
        {
            // obviously could hard code these values, but leaving as hex for 
            // ease of maintenance. not worried about perf here
            Color.TryParseHex("#007fff", out var azure);
            Color.TryParseHex("#1857a4", out var mandalorian);
            Color.TryParseHex("#215732", out var node);
            
            Color.TryParseHex("#d7dae0", out var grey);
            Color.TryParseHex("#528bff", out var blue);
            Color.TryParseHex("#56b6c2", out var cyan);
            Color.TryParseHex("#98c379", out var green);
            Color.TryParseHex("#7e0097", out var purple);
            Color.TryParseHex("#f44747", out var red);
            Color.TryParseHex("#e5c07b", out var yellow);

            var powershell = Color.FromRgb(1, 36, 86);
            var ubuntu = Color.FromRgb(48, 10, 36);

            var defaults = new (string Name, Color Color) []
            {
                ("ubuntu", ubuntu),
                ("azure", azure),
                ("mandalorian", mandalorian),
                ("node", node),
                ("powershell", powershell),
                ("blue", blue),
                ("cyan", cyan),
                ("green", green),
                ("purple", purple),
                ("red", red),
                ("yellow", yellow),
                ("grey", grey)
            };

            using var progressBar = new ProgressBar(defaults.Length * opts.Width.Length, "Creating images");
            foreach (var (name, color) in defaults)
            {
                foreach (var width in opts.Width)
                {
                    progressBar.Tick($"Building {name} ({width}px"); 
                    await BuildImages(name, color, width, opts.ImageWidth, opts.ImageHeight, opts.OutputLocation);    
                }
            }

            return 0;
        }

        private static async Task<int> CreateOne(CreateOneOptions opts)
        {
            await BuildImages(opts.Name, opts.Color.ParsedColor, opts.Width, opts.ImageWidth, opts.ImageHeight, opts.OutputLocation);
            return 0;
        }

        private static async Task BuildImages(string name, Color color, int lineWidth, int imageWidth, int imageHeight, string outputLocation)
        {
            if (Directory.Exists(outputLocation) == false)
            {
                Directory.CreateDirectory(outputLocation);
            }
            
            var vertical = new Rectangle(0, 0, lineWidth, imageHeight);
            var horizontal = new Rectangle(0,0, imageWidth, lineWidth);

            var pngEncoder = new PngEncoder()
            {
                ColorType = PngColorType.RgbWithAlpha
            };

            await WriteImage($"{name}-{lineWidth}px-vertical", vertical);
            await WriteImage($"{name}-{lineWidth}px-horizontal", horizontal);

            async Task WriteImage(string fileName, Rectangle rect)
            {
                using var image = new Image<Rgba32>(rect.Width, rect.Height);

                image.Mutate(x =>x.BackgroundColor(Color.Transparent));
                image.Mutate(x => x.Fill(color, rect));
                
                await image.SaveAsPngAsync(Path.Combine(outputLocation, $"{fileName}.png"), pngEncoder);
            }
        }
    }
}
