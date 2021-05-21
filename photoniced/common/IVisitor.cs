using System;
using System.Collections.Generic;


namespace photoniced.common
{

    public interface IVisitorElement
    {
        void Accept(IVisitor visitor);
    }


    public interface IVisitor
    {
        void Visit(IVisitorElement element);
    }







    public interface IFolder: IVisitorElement
    {
        string Name { get; set; }
        string Path { get; }

        IFolder Parent { get; }

        public IEnumerable<IFile> Files { get; }
        public IEnumerable<IFolder> Folders { get; }
    }

    public interface IFile: IVisitorElement
    {
        IFolder Parent { get; }
        string Name { get; set; }
        string Path { get; }
        DateTime Created { get; set; }
        DateTime Changed { get; set; }
        public long Size { get; }
    }


    public interface IDataProcessor: IVisitor
    {
        void Visit(IFolder element);
        void Visit(IFile element);
    }

}
