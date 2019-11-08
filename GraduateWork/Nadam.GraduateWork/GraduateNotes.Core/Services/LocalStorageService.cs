using GraduateNotes.Service.Contract.Interfaces;
using GraduateNotes.Service.Contract.Models;
using System;
using System.Linq;

namespace GraduateNotes.Service.Services
{
    class LocalStorageService : IStorageService
    {
        public string Root { get; set; }

        public File GetFile(string location, string title)
        {
            var nameAndExtension = GetNameAndExtension(title);
            if (!IsKnownExtension(nameAndExtension.extension))
                throw new Exception($"File does not have known extension: {nameAndExtension.extension}. File title: {title}");

            var file = new File();
            file.Extension = nameAndExtension.extension;
            file.Name = nameAndExtension.name;

            if (System.IO.File.Exists($"{Root}\\{location}\\{title}"))
            {                
                file.Content = System.IO.File.ReadAllText($"{Root}\\{location}\\{title}");
                file.Exist = true;
            }

            return file;
        }

        private (string name, string extension) GetNameAndExtension(string fileTitle)
        {
            var splitted = fileTitle.Split('.');
            if (splitted.Length < 2)
                throw new Exception($"Cannot obtain file name and extension! Given file title: {fileTitle}");

            var fileName = string.Join('.', splitted.Reverse().Skip(1).Reverse());

            return (
                fileName,
                splitted[splitted.Length-1]
            );
        }
    
        private bool IsKnownExtension(string extension)
        {
            var knownExtensions = new string[] { "html" };
            return knownExtensions.Contains(extension);
        }
    }
}
