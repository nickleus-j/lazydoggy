using System;
using System.Collections.Generic;
using System.Linq;
using Lazydog.Model;
using DaLazyDog.Models;

namespace DaLazyDog.ViewModelService
{
    public static class ViewModelCollectionMaker
    {
        public static IList<ExcuseViewModel> MakeListOfExcuseViewModel(ICollection<Excuse> excuses)
        {
            IList<ExcuseViewModel> viewModels = new List<ExcuseViewModel>();
            foreach(Excuse current in excuses)
            {
                viewModels.Add(new ExcuseViewModel(current));
            }
            return viewModels;
        }
    }
}
