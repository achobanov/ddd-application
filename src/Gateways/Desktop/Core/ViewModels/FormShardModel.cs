using EnduranceJudge.Gateways.Desktop.Core.Components.Templates.ListItem;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace EnduranceJudge.Gateways.Desktop.Core.ViewModels
{
    public class FormShardModel
    {
        private readonly object dependantCollection;
        private readonly object itemsCollection;
        private readonly MethodInfo addOrUpdateDependantStatic;
        private readonly MethodInfo clearItems;
        private readonly MethodInfo addItemsStatic;

        public FormShardModel(
            object dependantCollection,
            object itemsCollection,
            MethodInfo addOrUpdateDependantStatic,
            MethodInfo clearItems,
            MethodInfo addItemsStatic)
        {
            this.dependantCollection = dependantCollection;
            this.itemsCollection = itemsCollection;
            this.addOrUpdateDependantStatic = addOrUpdateDependantStatic;
            this.clearItems = clearItems;
            this.addItemsStatic = addItemsStatic;
        }

        public IList GetDependants()
        {
            return this.dependantCollection as IList;
        }

        public void AddOrUpdateDependant(DependantFormBase dependant)
        {
            this.addOrUpdateDependantStatic.Invoke(null, new[] { this.dependantCollection, dependant });
        }

        public void RefreshItems(IEnumerable<ListItemViewModel> items)
        {
            this.clearItems.Invoke(this.itemsCollection, Array.Empty<object>());
            this.addItemsStatic.Invoke(null, new[] { this.itemsCollection, items } );
        }
    }
}
