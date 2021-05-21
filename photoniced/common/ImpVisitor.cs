using System;
using System.Collections.Generic;
using IO = System.IO;

namespace photoniced.common
{
    public class Folder : IFolder
    {
        private IO.DirectoryInfo m_Info;

        public IFolder Parent
        {
            get
            {
                return new Folder(m_Info.Parent);
            }
        }

        public IEnumerable<IFile> Files
        {
            get
            {
                foreach(var file in m_Info.GetFiles())
                    yield return new File(file);
            }
        }

        public IEnumerable<IFolder> Folders
        {
            get
            {
                foreach (var folder in m_Info.GetDirectories())
                    yield return new Folder(folder);
            }
        }

        public string Name
        {
            get => m_Info.Name;
            set
            {
                if (value == m_Info.Name)
                    return;

                try
                {
                    var newPath = IO.Path.Combine(m_Info.Parent.FullName, value);
                    m_Info.MoveTo(newPath);
                }
                catch(Exception)
                { }
            }
        }
        public string Path => m_Info.FullName;

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }


        public Folder(string path)
        {
            m_Info = new IO.DirectoryInfo(Required.NotNullOrEmpty(path, nameof(path)));
        }

        public Folder(IO.DirectoryInfo info)
        {
            m_Info = Required.NotNull(info, nameof(info));
        }
    }

    public class File : IFile
    {
        private IO.FileInfo m_Info;
        public string Name
        {
            get
            {
                return m_Info.Name;
            }
            set
            {
                if (value == m_Info.Name)
                    return;

                try
                {
                    var newPath = IO.Path.Combine(m_Info.Directory.FullName, value);
                    m_Info.MoveTo(newPath);
                }
                catch (Exception)
                { }

            }
        }
        public DateTime Created
        {
            get => m_Info.CreationTime;
            set
            {
                m_Info.CreationTime = value;
            }
        }
        public DateTime Changed
        {
            get => m_Info.LastWriteTime;
            set
            {
                m_Info.LastWriteTime = value;
            }
        }

        public long Size => m_Info.Length;


        public IFolder Parent => new Folder(m_Info.Directory);
        public string Path => m_Info.FullName;

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public File(string path)
        {
            m_Info = new IO.FileInfo( Required.NotNullOrEmpty(path, nameof(path)));
        }

        public File(IO.FileInfo info)
        {
            m_Info = Required.NotNull(info, nameof(info));
        }
    }







    class MoveByCreationDate : IDataProcessor
    {
        public DateTime CreationDate { get; }
        public IFolder  DestFolder { get; }


        public MoveByCreationDate(IFolder dest, DateTime creationDate)
        {
            this.CreationDate = creationDate;
            this.DestFolder = Required.NotNull(dest, nameof(dest));
        }

        public void MoveFiles(IFolder src)
        {
            src.Accept(this);
        }

        public void Visit(IFolder element)
        {
            foreach (var subfolder in element.Folders)
                subfolder.Accept(this);

            foreach (var files in element.Files)
                files.Accept(this);
        }

        public void Visit(IFile element)
        {
            if (element.Created.Year == CreationDate.Year && 
                element.Created.Day == CreationDate.Day &&
                element.Created.Month == CreationDate.Month)
            {
                IO.File.Move(element.Path, IO.Path.Combine(this.DestFolder.Path, element.Name));
            }
        }

        public void Visit(IVisitorElement element)
        {}
    }

}
