using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Management.Instrumentation;
using System.Web;
using Apriorit.HierarchyStructure.Mvc.DAL;
using Apriorit.HierarchyStructure.Mvc.Models;

namespace Apriorit.HierarchyStructure.Mvc.BL
{
    public class FoldersFacade : IFoldersFacade
    {
        private readonly IFolderRepository _repository;

        public FoldersFacade(IFolderRepository repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }
            _repository = repository;
        }

        public FoldersViewModel GetPathContent(string path)
        {
            var splited = path.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            if (splited == null || splited.Count == 0)
            {
                return CreateFolderViewModel(null,"[..]");
            }
            else
            {
                var depth = splited.Count;
                var lastFolder = splited.Last();

                var content = _repository.GetFoldersTree(lastFolder, depth);

                var parentNodeId = FindLastFolderIdInTree(splited, content);

                return CreateFolderViewModel(parentNodeId, lastFolder);
            }
        }

        private static int? FindLastFolderIdInTree(List<string> splited, ICollection<FolderEntity> content)
        {
            int? parentNodeId = null;

            var finished = false;
            while (!finished)
            {
                string element = splited.First();
                splited.RemoveAt(0);

                var elements = content.Where(e => e.ParentId == parentNodeId && e.Name.Equals(element));

                if (elements.Count() != 1)
                {
                    throw new ApplicationException($"Folder {element} should exists and be unique");
                }

                parentNodeId = elements.Single().Id;

                finished = splited.Count <= 0;
            }

            if (!parentNodeId.HasValue)
            {
                throw new ArgumentNullException(nameof(parentNodeId));
            }
            return parentNodeId;
        }

        private FoldersViewModel CreateFolderViewModel(int? parentNodeId, string name)
        {
            var model = new FoldersViewModel();
            model.CurrentFolder = name;
            model.SubFolders = CreateSubfolders(parentNodeId);
            return model;
        }

        private ICollection<FolderViewModel> CreateSubfolders(int? parentNodeId)
        {
            var content = _repository.GetFolderContent(parentNodeId);

            var result = new Collection<FolderViewModel>();
            foreach (var entity in content)
            {
                var newItem = new FolderViewModel() { Name = entity.Name };
                result.Add(newItem);
            }
            return result;
        }
    }
}