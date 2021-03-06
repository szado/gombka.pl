﻿using System;
using System.Diagnostics;
using Gombka.pl.Models;
using System.Text;

namespace Gombka.pl.Helpers
{
    public class FFMPEGHelper
    {
        public const string THUMB_EXT = ".webp";
        public const string THUMB_MIME_TYPE = "image/webp";

        private readonly Config Config;
        private const int DEFAULT_WIDTH_PX = 320;
        private const int DEFAULT_HEIGHT_PX = 180;

        public FFMPEGHelper(Config config)
        {
            Config = config;
        }

        public void CreateThumbnailFromVideo(string videoPath, string thumbnailFilename)
        {
            try
            {
                var startInfo = new ProcessStartInfo
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = "cmd.exe",
                    Arguments = CreateCommand(videoPath, thumbnailFilename)
                };
                var process = new Process
                {
                    StartInfo = startInfo
                };

                process.Start();
                process.WaitForExit();
            } catch (Exception e)
            {

            }
        }

        private string CreateCommand(
            string videoPath, 
            string thumbnailFilename,
            int thumbnailWidth = DEFAULT_WIDTH_PX,
            int thumbnailHeight = DEFAULT_HEIGHT_PX
        ) {
            StringBuilder path = new StringBuilder();

            path.Append(GetCommandPrefix());
            path.Append(Config.FFMPEGExecutablePath);
            path.Append(ProvideInputFilename(videoPath));
            path.Append(GetFrame());
            path.Append(ExcludeAudio());
            path.Append(GetOutputSize(thumbnailWidth, thumbnailHeight));
            path.Append(GetThumbnailFromSecond());
            path.Append(ProvideOutputFilename(thumbnailFilename));

            return path.ToString();
        }

        private string GetCommandPrefix()
        {
            return "/C ";
        }

        private string ProvideInputFilename(string videoPath)
        {
            return $" -i {videoPath} ";
        }

        private string GetFrame()
        {
            return $"-vframes 1 ";
        }

        private string ExcludeAudio()
        {
            return $"-an ";
        }

        private string GetOutputSize(int width, int height)
        {
            return $"-s {width}x{height} ";
        }

        private string GetThumbnailFromSecond(int second = 1)
        {
            return $"-ss {second} ";
        }

        public string ProvideOutputFilename(string fileName)
        {
            StringBuilder name = new StringBuilder();
            name
                .Append(Config.StoredThumbnailsPath)
                .Append(fileName)
                .Append(THUMB_EXT);

            return name.ToString();
        }
    }
}
