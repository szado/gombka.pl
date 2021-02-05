using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gombka.pl.Models
{
    public class Config
    {
        public readonly IConfiguration Parsed;

        public Config(IConfiguration configuration)
        {
            Parsed = configuration;
        }

        public int VideoMaxBytes
        {
            get
            {
                try
                {
                    return int.Parse(Parsed["Videos:MaxBytes"]);
                } 
                catch (Exception)
                {
                    return 100_000_000;
                }
            }
        }

        public double VideoMaxMb
        {
            get => Convert.ToDouble(VideoMaxBytes / 100_000);
        }

        public string[] AllowedVideoMimeTypes
        {
            get => this.Parsed.GetSection("Videos:AllowedContentTypes").Get<string[]>();
        }
    }
}
